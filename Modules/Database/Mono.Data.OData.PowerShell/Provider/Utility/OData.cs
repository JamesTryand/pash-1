/*
	Copyright (c) 2012 Code Owls LLC

	Permission is hereby granted, free of charge, to any person obtaining a copy 
	of this software and associated documentation files (the "Software"), to 
	deal in the Software without restriction, including without limitation the 
	rights to use, copy, modify, merge, publish, distribute, sublicense, and/or 
	sell copies of the Software, and to permit persons to whom the Software is 
	furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in 
	all copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
	FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
	IN THE SOFTWARE. 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Mono.Data.PowerShell.Provider;

namespace Mono.Data.OData.Provider
{
    internal class ODataHelper
    {
        private readonly XDocument _metadata;

        public ODataHelper( XDocument metadata )
        {
            _metadata = metadata;
        }

        public Uri UriGetUriForEntityName(Uri uri, string nodeName)
        {
            var setName = uri.Segments.Last();
            var entitySets = _metadata.Descendants(Names.EntitySet).ToList();
            if( ! entitySets.Any() )
            {
                entitySets = _metadata.Descendants(Names.EntitySetMetadata).ToList();
            }

            var entitytypename = (
                               from set in entitySets
                               let name = set.Attribute(Names.NameAttribute).Value
                               where StringComparer.InvariantCultureIgnoreCase.Equals(setName, name)
                               select set.Attribute(Names.EntityTypeAttribute).Value).FirstOrDefault();
            if( null == entitytypename )
            {
                return null;
            }

            var propertyName = GetKeyPropertyNameForEntityType(entitytypename);
            if( null == propertyName )
            {
                return null;
            }

            return new Uri( uri, String.Format( "?$filter={0} eq '{1}'", propertyName, nodeName));
        }

        private string GetKeyPropertyNameForEntityType(string entitytypename)
        {
            var typename = entitytypename.Split('.').Last();
            var ns = entitytypename.Substring(0, entitytypename.Length - typename.Length - 1);

            var propertyName =
                _metadata
                    .Descendants(Names.Schema)
                    .Where(s => s.Attribute(Names.NamespaceAttribute).Value == ns)
                    .Descendants(Names.EntityType)
                    .Where(e => e.Attribute(Names.NameAttribute).Value == typename)
                    .Descendants(Names.PropertyRef)
                    .Attributes(Names.NameAttribute)
                    .FirstOrDefault();

            if (null == propertyName)
            {
                propertyName =
                    _metadata
                        .Descendants(Names.SchemaMetadata)
                        .Where(s => s.Attribute(Names.NamespaceAttribute).Value == ns)
                        .Descendants(Names.EntityTypeMetadata)
                        .Where(e => e.Attribute(Names.NameAttribute).Value == typename)
                        .Descendants(Names.PropertyRefMetadata)
                        .Attributes(Names.NameAttribute)
                        .FirstOrDefault();
            }
            if (null == propertyName)
            {
                return null;
            }

            return propertyName.Value;
        }

        public string GetEntityName(XElement element)
        {
            var term = element.Descendants(Names.Category).Attributes(Names.TermAttribute).FirstOrDefault();
            if( null == term )
            {
                return GetDefaultEntityName(element);
            }

            var propertyName = GetKeyPropertyNameForEntityType(term.Value);
            if( null == propertyName )
            {
                return GetDefaultEntityName(element);
            }

            var value =
                (from pe in
                     element.Descendants(Names.Properties).Descendants(XName.Get(propertyName, Namespaces.DataServices))
                 select pe.Value).FirstOrDefault();
            if( null == value )
            {
                return GetDefaultEntityName(element);
            }

            return value;
        }

        private string GetDefaultEntityName(XElement element)
        {
            return element.Descendants(Names.Title).First().Value;
        }
    }
}
