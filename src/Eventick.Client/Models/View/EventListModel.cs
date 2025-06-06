﻿using Eventick.Web.Models.Api;
using System;
using System.Collections.Generic;

namespace Eventick.Web.Models.View
{
    public class EventListModel
    {
        public IEnumerable<Event> Events { get; set; }
        public Guid SelectedCategory { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int NumberOfItems { get; set; }
    }
}
