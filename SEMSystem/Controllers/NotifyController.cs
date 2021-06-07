using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEMSystem.Models;
using SEMSystem.Models.View_Model;

namespace SEMSystem.Controllers
{
    public class NotifyController : Controller
    {
        private readonly SEMSystemContext _context;
        public NotifyController(SEMSystemContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
        public string SendNotification(string docstatus, string equipmenttype, int id)
        {
            int compid = 0;
            var notify = new NotifyViewModel();

            switch (equipmenttype)
            {
                case "fe":
                    var _fe = _context.FireExtinguisherHeaders.Find(id);
                    notify.Area = _fe.Locations.Areas.Name;
                    notify.CompanyId = _fe.Locations.Areas.CompanyId;
                    notify.DocumentStatus = docstatus;
                    notify.Equipment = "Fire Extinguisher";
                    notify.Location = _fe.Locations.Location;
                    break;
                case "el":
                    var _el = _context.EmergencyLightHeaders.Find(id);
                    notify.Area = _el.Locations.Areas.Name;
                    notify.CompanyId = _el.Locations.Areas.CompanyId;
                    notify.DocumentStatus = docstatus;
                    notify.Equipment = "Emergency Light";
                    notify.Location = _el.Locations.Location;
                    break;
                case "it":
                    var _it = _context.FireExtinguisherHeaders.Find(id);
                    notify.Area = _it.Locations.Areas.Name;
                    notify.CompanyId = _it.Locations.Areas.CompanyId;
                    notify.DocumentStatus = docstatus;
                    notify.Equipment = "Inergen Tank";
                    notify.Location = _it.Locations.Location;
                    break;
                case "fh":
                    var _fh = _context.FireExtinguisherHeaders.Find(id);
                    notify.Area = _fh.Locations.Areas.Name;
                    notify.CompanyId = _fh.Locations.Areas.CompanyId;
                    notify.DocumentStatus = docstatus;
                    notify.Equipment = "Fire Hydrant";
                    notify.Location = _fh.Locations.Location;
                    break;

            };


            string status = "";
            string message = SendEmail(notify);

            if (message != "success")
            {
                status = "fail";
            }
            else
            {
                status = "success";
            }


            return message;
        }
        private string SendEmail(NotifyViewModel nvm)
        {

            string email = "";

            string message = "";
            string rply = "";
            string revieweremail = "";
            string approveremail = "hblucy@semirarampc.com";
            string recipient = "";


            try
            {
                switch (nvm.DocumentStatus)
                {
                    case "For Review":
                        if (nvm.CompanyId == 1) //slpgc
                        {
                            ////gbarroyo
                            //revieweremail = "gbarroyo@slpowergen.com";
                            revieweremail = "kcmalapit@semirarampc.com";
                        }
                        else
                        {
                            ////eccueto
                            //revieweremail = "eccueto@semcalaca.com";
                            revieweremail = "rpgustilo@semirarampc.com";
                        }
                        message = "There a form For Review with Reference No : "  + nvm.ReferenceNo + ",Area :" + nvm.Area + " ,Location: " + nvm.Location;
                        break;
                    case "For Approval":
                        message = "There a form For Approval with Reference No : " + nvm.ReferenceNo + ",Area :" + nvm.Area + " ,Location: " + nvm.Location;
                        break;
                    default:
                        break;
                }

                int deptId = 0;
                
                string msg = "Hi, <br /><br />" + message + ". <br /><br />";

                var body = msg;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("webhelpdeskadmin@semcalaca.com", "Safety Equipment Monitoring System");


                if (nvm.DocumentStatus == "For Review")
                {
                    mail.To.Add(new MailAddress(revieweremail));
                    recipient = revieweremail;
                }
                else
                {
                    mail.To.Add(new MailAddress(approveremail));
                    recipient = approveremail;
                }
                


                mail.Subject = "Safety Equipment Monitoring System";
                mail.Body = string.Format(body + " Click on this link to view details. http://192.168.30.182/SEM/");
                mail.IsBodyHtml = true;

                using (var smtp = new SmtpClient()) //mail server
                {
                    try
                    {
                        smtp.Host = "mail.cpcaccess.com";
                        smtp.Credentials = new System.Net.NetworkCredential("webhelpdeskadmin@semcalaca.com", "System@1");
                        smtp.Port = 587;
                        smtp.EnableSsl = false;
                        smtp.Send(mail);
                        rply = "success";

                    }
                    catch (Exception e)
                    {
                        WriteLog(e.Message + " Time : " + DateTime.Now + " \r\n", true);
                        rply = e.Message;

                    }

                }


            }
            catch (Exception e)
            {
                WriteLog(e.Message + " Time : " + DateTime.Now + " \r\n", true);
                rply = e.Message.ToString();
            }

            Log log = new Log();
            log.Action = "Send Email";
            log.Descriptions = "Send EMAIL by Header Referenceno : " + nvm.ReferenceNo + ", Recipient : " + recipient;
            log.Status = rply;
            _context.Logs.Add(log);
            _context.SaveChanges();

            return rply;
        }
        private void WriteLog(string text, bool append)
        {
            StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\log.txt", append);
            sw.Write(text);
            sw.Close();
        }
    }
   
}