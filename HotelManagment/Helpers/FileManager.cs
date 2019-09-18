using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HotelManagment.Helpers
{
    public static class FileManager
    {
        public static string Upload(HttpPostedFileBase File)
        {

            var postFile = File.FileName.Split('.');

            string filename = Guid.NewGuid().ToString() + "." + postFile[postFile.Length - 1];

            //Controlerin icinde Server yaza bilirik
            //Controler bir basa requeste cavab verdiyi ucun mumkundur ama burda birbasa
            //yaza bilmerik.Ona gore de asagidaki kimi yazriq :

            string path = Path.Combine(HttpContext.Current.Server.MapPath("/Uploads"), filename);


            File.SaveAs(path);

            return filename;
        }

        public static void Delete(string File)
        {

            string path = Path.Combine(HttpContext.Current.Server.MapPath("/Uploads"), File);

            if (System.IO.File.Exists(path))
            {

                System.IO.File.Delete(path);
            }
        }

    }
}