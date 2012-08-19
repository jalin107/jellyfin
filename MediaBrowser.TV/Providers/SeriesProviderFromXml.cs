﻿using System.ComponentModel.Composition;
using System.Threading.Tasks;
using MediaBrowser.Controller.Events;
using MediaBrowser.Controller.Providers;
using MediaBrowser.Model.Entities;
using MediaBrowser.TV.Entities;
using MediaBrowser.TV.Metadata;

namespace MediaBrowser.TV.Providers
{
    [Export(typeof(BaseMetadataProvider))]
    public class SeriesProviderFromXml : BaseMetadataProvider
    {
        public override bool Supports(BaseItem item)
        {
            return item is Series;
        }

        public async override Task Fetch(BaseItem item, ItemResolveEventArgs args)
        {
            var metadataFile = args.GetFileByName("series.xml");

            if (metadataFile.HasValue)
            {
                await new SeriesXmlParser().Fetch(item as Series, metadataFile.Value.Key);
            }
        }
    }
}
