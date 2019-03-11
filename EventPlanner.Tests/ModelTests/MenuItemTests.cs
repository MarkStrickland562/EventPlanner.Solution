using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventPlanner.Models;
using System.Collections.Generic;
using System;

namespace EventPlanner.Tests
{
  [TestClass]
  public class MenuItemTest : IDisposable
  {

    public EventTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=event_planner_test;";
    }

    public void Dispose()
    {
      Event.ClearAll();
    }


  }
}