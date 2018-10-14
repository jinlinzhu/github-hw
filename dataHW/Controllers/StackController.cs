using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dataHW.Controllers
{
    public class StackController : Controller
    {
        //Global variables
        static Stack<string> myStack = new Stack<string>();
        string sResult;

        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.StackView = myStack;
            return View();
        }

        //Generates a new value and inserts it into the stack.
        public ActionResult AddOne()
        {
            myStack.Push("New Entry " + (myStack.Count + 1));
            return RedirectToAction("Index", "Stack");
        }

        //Clears the stack, then generates and adds 2000 items to the stack
        public ActionResult AddMany()
        {
            myStack.Clear();
            for (int i = 0; i < 2000; i++)
            {
                myStack.Push("New Entry " + (myStack.Count + 1));
            }
            return RedirectToAction("Index", "Stack");
        }

        //Displays the contents of the stack to the _________ view.
        public ActionResult Display()
        {
            ViewBag.StackView = myStack;
            return RedirectToAction("Index", "Stack");
        }

        //Deletes an item from the stack. Handles errors and informs users if it cannot delete.
        public ActionResult DeleteFrom()
        {
            myStack.Pop();
            //ViewBag.StackView = myStack;
            return RedirectToAction("Index", "Stack");
        }

        //Wipes out the contents of the stack.
        public ActionResult Clear()
        {
            myStack.Clear();
            return RedirectToAction("Index", "Stack");
        }

        //Searches for a hard-coded item in the stack, returns if it was found or not found and how long the search took
        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            //loop to do all the work
            foreach (var sData in myStack)
            {
                if (sData == "New Entry 37")
                {
                    sResult = "New Entry 37 was found.";
                    
                }
                else
                {
                    sResult = "New Entry 37 was not found.";
                }
            }
            //I DON'T KNOW WHY THE VIEWBAG.RESULT and VIEWBAG.STOPWATCH ARE NOT BEING DISPLAYED IN THE VIEW.
            ViewBag.Result = sResult;

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            ViewBag.StopWatch = ts;

            return RedirectToAction("Index", "Stack");
        }

        //Returns to the main menu (the Index view of the home controller)
        public ActionResult Exit()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}