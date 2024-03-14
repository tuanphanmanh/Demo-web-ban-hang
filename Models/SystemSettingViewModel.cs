﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models
{
    public class SystemSettingViewModel
    {
        public string SettingTitle { get; set; }
        public string SettingLogo { get; set; }
        public string SettingHotline { get; set; }
        public string SettingEmail { get; set; }
        public string SettingTitleSeo { get; set; }
        public string SettingDesSeo { get; set; }
        public string SettingKeySeo { get; set; }
    }
}