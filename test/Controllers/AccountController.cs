using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(PersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                using (DataModel db = new DataModel())
                {
                    var obj = db.People.Where(a => a.Name.Equals(person.Name) && a.Password.Equals(person.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.Name.ToString();
                        Session["Surname"] = obj.Surname.ToString();

                        obj.LastLogin = DateTime.UtcNow;
                        db.Entry(obj).State = EntityState.Modified;
                        var result = await db.SaveChangesAsync() == 0 ? null : "ok";

                        return RedirectToAction("Edit", new { id = obj.Id });
                    }
                }
            }

            ViewBag.permission = "Login Failed, Please make sure Username and Password are correct";
            return View(person);
        }

       
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["UserID"] != null || Session["UserName"] != null)
            {
                using (DataModel db = new DataModel())
                {
                    var obj = db.Infoes.Where(a => a.PersonId.Equals(id) ).FirstOrDefault();
                    if (obj != null)
                    {
                        InfoViewModel model = new InfoViewModel
                        {
                            id = obj.PersonId,
                            TelNo = obj.TelNo,
                            AddressLine1 = obj.AddressLine1,
                            AddressLine2 = obj.AddressLine2,
                            AddressLine3 = obj.AddressLine3,
                            AddressCode = obj.AddressCode,
                            PostalAddress1 = obj.PostalAddress1,
                            PostalAddress2 = obj.PostalAddress2,
                            PostalCode = obj.PostalCode
                        };

                        ViewBag.userID = obj.PersonId;
                        return View(model);
                    }
                }
            }

            return RedirectToAction("Login");
        }

        // POST: Account/Edit/5
        public async Task<JsonResult> Update(string person,string password)
        {
            try
            {
                if (Session["UserID"] != null || Session["UserName"] != null)
                {
                    Info obj = JsonConvert.DeserializeObject<Info>(person);

                    using (DataModel db = new DataModel())
                    {
                        var entity = db.Infoes.Where(a => a.PersonId.Equals(obj.PersonId)).FirstOrDefault();
                        entity.TelNo = obj.TelNo;
                        entity.AddressLine1 = obj.AddressLine1;
                        entity.AddressLine2 = obj.AddressLine2;
                        entity.AddressLine3 = obj.AddressLine3;
                        entity.AddressCode = obj.AddressCode;
                        entity.PostalAddress1 = obj.PostalAddress1;
                        entity.PostalAddress2 = obj.PostalAddress2;
                        entity.PostalCode = obj.PostalCode;

                        db.Entry(entity).State = EntityState.Modified;
                        var result = await db.SaveChangesAsync() == 0 ? null : entity;

                        if (result != null)
                        {
                            if(!string.IsNullOrEmpty(password))
                            {
                                var data = db.People.Where(a => a.Id.Equals(obj.PersonId)).FirstOrDefault();
                                data.Password = password;
                                db.Entry(entity).State = EntityState.Modified;
                                var res = await db.SaveChangesAsync() == 0 ? null : entity;
                            }

                            return new JsonResult()
                            {
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                                Data = new { result = "Success", message = "User Info was successfully saved" }
                            };
                        }
                    }
                }

                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { result = "Error", message = "Failed to update user info" }
                };
            }
            catch(Exception e)
            {
                var msg = e.Message;
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { result = "Error", message = "Failed to update user info" }
                };
            }
        }
    }
}
