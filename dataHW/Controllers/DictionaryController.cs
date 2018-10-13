using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dataHW.Controllers
{
    public class DictionaryController : Controller
    {
        static Dictionary<string, int> myDictionary = new Dictionary<string, int>();

        // GET: Dictionary
        public ActionResult Index()
        {
            ViewBag.MyDictionary = myDictionary;
            return View();
        }

        //Add One item to dictionary and update viewbag
        public ActionResult AddOne()
        {
            myDictionary.Add(("New Entry " + (myDictionary.Count + 1)), (myDictionary.Count + 1));
            return View("Index");
        }

        //Add huge list of items to dictionary and update viewbag
        public ActionResult AddList()
        {
            //clear dictionary
            myDictionary.Clear();

            //add items
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myDictionary.Add("New Entry " + (myDictionary.Count + 1), (myDictionary.Count + 1));
            }

            return View("Index");
        
        }

        //Display dictionary
        public ActionResult Display()
        {
            //if Dictionary is empty, tell user
            if (myDictionary.Count == 0)
            {
                ViewBag.MyDictionary = "No items in Dictionary";
            }
            
            //load ViewBag with dictionary
            else
            {
                foreach (var item in myDictionary)
                {
                    ViewBag.MyDictionary = ViewBag.MyDictionary + item;
                }
            }

            return View("Index");
        }

        //Delete an item from Dictionary
        public ActionResult Delete()
        {
            //if Dictionary is empty, tell user
            if (myDictionary.Count == 0)
            {
                ViewBag.MyDictionary = "No items in Dictionary";
            }

            //delete item
            else
            {
                myDictionary.Remove(myDictionary.Keys.Last());
            }

            return View("Index");
        }

        //clear contents
        public ActionResult Clear()
        {
            myDictionary.Clear();
            return View("Index");
        }

        //search dictionary
        public ActionResult Search()
        {
            foreach(var item in myDictionary.Values)
            {
                if(item == 4)
                {
                    ViewBag.MyDictionary = "Item found";
                }
                else
                {
                    ViewBag.MyDictionary = "No Item found";
                }
            }

            return View("Index");
        }
    }
}