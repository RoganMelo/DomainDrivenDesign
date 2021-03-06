﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace DomainDrivenDesign.Presentation.ViewModels.Identity
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<SelectListItem> Providers { get; set; }
    }
}
