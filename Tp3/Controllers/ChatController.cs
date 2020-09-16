using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TPModule5_1.Models;
using TPModule5_1.Utils;

namespace TPModule5_1.Controllers
{
    public class ChatController : Controller
    {
        //private static List<Chat> chats = Chat.GetMeuteDeChats();

        // GET: Chat
        public ActionResult Index()
        {
            //return View(chats);
            return View(FakeDbCat.Instance.Chats);
        }

        public ActionResult Create()
        {
            ChatCreateViewModel vm = new ChatCreateViewModel();
            vm.Couleurs = FakeDbCat.Instance.Couleurs;
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(ChatCreateViewModel vm)
        {
            try
            {
                //vm.Couleurs = FakeDbCat.Instance.Couleurs;
                vm.Chat.Couleur = FakeDbCat.Instance.Couleurs.FirstOrDefault(x => x.Id == vm.IdCouleur);
                FakeDbCat.Instance.Chats.Add(vm.Chat);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            Chat chat = FakeDbCat.Instance.Chats.FirstOrDefault(x => x.Id == id);
            if (chat != null)
            {
                return View(chat);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            Chat chat = FakeDbCat.Instance.Chats.FirstOrDefault(x => x.Id == id);
            if (chat != null)
            {
                return View(chat);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Chat chat = FakeDbCat.Instance.Chats.FirstOrDefault(x => x.Id == id);
                FakeDbCat.Instance.Chats.Remove(chat);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(id);
            }
        }
    }
}
