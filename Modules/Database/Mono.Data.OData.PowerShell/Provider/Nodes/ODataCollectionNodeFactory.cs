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
using System.Xml.Linq;
using Mono.Data.PowerShell.Provider;
using Mono.Data.PowerShell.Provider.PathNodes;
using Mono.Data.PowerShell.Provider.PathNodeProcessors;

namespace Mono.Data.OData.Provider
{
    public class ODataCollectionNodeFactory : ODataNodeFactoryBase
    {
        public ODataCollectionNodeFactory(Uri uri, XDocument metadata, XElement element) : base( uri, metadata, element, "Collection" )
        {
        }

        public override object GetNodeChildrenParameters
        {
            get { return new ODataDynamicParameters(); }
        }

        public override IEnumerable<INodeFactory> Resolve(IContext context, string nodeName)
        {
            if( null == nodeName )
            {
                return base.Resolve(context, null );
            }

            var helper = new ODataHelper(_metadata);
            var childUri = helper.UriGetUriForEntityName(_uri, nodeName);
            
            XDocument document = GetODataDocument( childUri );
            return from entity in document.Descendants(Names.Entry)
                   let id = entity.Descendants( Names.Id ).First().Value
                   let node = new ODataEntryNodeFactory( new Uri( id ), _metadata, entity)
                   where StringComparer.InvariantCultureIgnoreCase.Equals(node.Name, nodeName)
                   select (INodeFactory)node;
        }

        public override IEnumerable<INodeFactory> GetNodeChildren( IContext context )
        {
            XDocument document = GetODataDocument( context );

            var entries = GetEntries( document );
            var entryFactories = new List<INodeFactory>();
            foreach( var entry in entries )
            {
                var id = entry.Descendants(Names.Id).First().Value;
                entryFactories.Add( new ODataEntryNodeFactory(new Uri( id ), _metadata, entry) );
            }

            var next = GetNextResultSetURI(document);
            if( null != next && ! context.Force )
            {
                context.WriteWarning( 
                    String.Format(
                        @"The OData collection at URI [{0}] has returned a partial result set.  
Specify the -force parameter to retrieve the complete result set, or narrow your query using the -filter parameter.
For more information on filtering, type:
get-help about_OData_Query",
                        BaseUri
                    ) 
                );
            }

            // resolve all <link rel="next" /> when -force is supplied
            if( context.Force )
            {                
                while( null != next )
                {
                    var xdoc = XDocumentManager.Get(next);
                    entries = GetEntries(xdoc);
                    foreach (var entry in entries)
                    {
                        var id = entry.Descendants(Names.Id).First().Value;
                        entryFactories.Add(new ODataEntryNodeFactory(new Uri(id), _metadata, entry));
                    }
                    next = GetNextResultSetURI(xdoc);
                }
            }

            return entryFactories;
        }

        private Uri GetNextResultSetURI( XDocument xdoc )
        {
            var r = xdoc.Descendants(Names.Link).Attributes(Names.RelAttribute).FirstOrDefault(a => a.Value == "next");
            if( null == r || String.IsNullOrEmpty( r.Value ))
            {
                return null;
            }

            string nextUri = r.Parent.Attribute( Names.HrefAttribute ).Value;
            return new Uri( BaseUri, nextUri );
        }

        private IEnumerable<XElement> GetEntries( XDocument xdoc )
        {
            var entries = xdoc.Descendants(Names.Entry);
            return entries;
        }
    }
}
