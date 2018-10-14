using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace dataHW.Controllers
{
    public class QueueController : Controller
    {
        //Create new Queue
        static Queue<string> myQueue = new Queue<string>();
        static string message;
        // GET: Queue
        public ActionResult Index()
        {
            ViewBag.Message = message;
            ViewBag.MyQueue = myQueue;
            return View();
        }
        public ActionResult AddOne()
        {
            //add new entries to the Queue
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            //Display current Queue entries
            message = "Entries in Queue: " + myQueue.Count();
            ViewBag.Message = message;
            return RedirectToAction("Index", "Queue");
        }
        public ActionResult AddHugeList()
        {
            //Clear the Queue
            myQueue.Clear();
            //Load 2,000 items into the Queue
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                //Display "New Entry and #"
                myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            }
            //display current Queue
            message = "Queue contains " + myQueue.Count() + " entries.";
            ViewBag.Message = message;
            return RedirectToAction("Index", "Queue");
        }
        public ActionResult Display()
        {
            //Display the current items in the Queue
            if (myQueue.Count > 0)
            {
                foreach (Object obj in myQueue)
                {
                    myQueue.Peek();
                }

            }
            else
            {
                message = "Queue is empty";
            }

            ViewBag.Message = message;
            ViewBag.MyQueue = myQueue;
            return RedirectToAction("Index", "Queue");
        }
        public ActionResult DeleteFrom()
        {
            //delete any item and inform user if it cannot delete
            if (myQueue.Count > 0)
            {
                myQueue.Dequeue();
                message = "An entry was deleted from the Queue.";

            }
            else
            {
                message = "The Entry was not deleted because the Queue is empty.";

            }
            //display message to the user
            ViewBag.Message = message;
            return RedirectToAction("Index", "Queue");
        }
        public ActionResult Clear()
        {
            myQueue.Clear();
            message = "Queue has been cleared.";
            ViewBag.Message = message;
            return RedirectToAction("Index", "Queue");
        }
        public ActionResult Search()
        {
            //stopwatch code
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            //loop to do all the work
            myQueue.ToArray();

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            ViewBag.StopWatch = ts;
            return RedirectToAction("Index", "Queue");
        }
        public ActionResult Return()
        {
            return RedirectToAction("Index", "Index");
        }
    }
}
