using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Helpers
{
    public class LoadData
    {
        public static SelectList LoadDataStyles()
        {
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                return new SelectList(service.GetSongStyle(), "Id", "Title"); // title - вижд се от потребителя, Id - се изпраща към контролелр

            }
        }
    }
}