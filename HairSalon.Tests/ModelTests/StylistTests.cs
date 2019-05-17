using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTests : IDisposable
  {
    public void Dispose()
    {
      Stylist.ClearAll();
      Client.ClearAll();
    }

    public StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;port=3306;database=reese_lee_test;";
    }

   [TestMethod]
   public void GetAll_StylistsEmptyAtFirst_0()
   {
     //Arrange, Act
     int result = Stylist.GetAll().Count;

     //Assert
     Assert.AreEqual(0, result);
   }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Stylist()
    {
      //Arrange, Act
      Stylist firstStylist = new Stylist("Lizzy Ding", 2);
      Stylist secondStylist = new Stylist("Lizzy Ding", 2);

      //Assert
      Assert.AreEqual(firstStylist, secondStylist);
    }

    [TestMethod]
    public void Save_SavesStylistToDatabase_StylistList()
    {
      //Arrange
      Stylist testStylist = new Stylist("Joanna Fang", 2);
      testStylist.Save();

      //Act
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist> { testStylist };

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

     [TestMethod]
     public void Save_DatabaseAssignsIdToStylist_Id()
     {
       //Arrange
       Stylist testStylist = new Stylist("Charissa Laryx", 3);
       testStylist.Save();

       //Act
       Stylist savedStylist = Stylist.GetAll()[0];

       int result = savedStylist.Id;
       int testId = testStylist.Id;

       //Assert
       Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Find_FindsStylistInDatabase_Stylist()
    {
      //Arrange
      Stylist testStylist = new Stylist("Opal Juicy", 2);
      testStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(testStylist.Id);

      //Assert
      Assert.AreEqual(testStylist, foundStylist);
    }

    [TestMethod]
    public void GetClients_RetrievesAllClientsWithStylist_ClientList()
    {
        //Arrange, Act
        Stylist testStylist = new Stylist("Vanna Hiroi", 4);
        testStylist.Save();
        Client firstClient = new Client("Ned Good", testStylist.Id);
        firstClient.Save();
        Client secondClient = new Client("Frannie Hernandez", testStylist.Id);
        secondClient.Save();
        List<Client> testClientList = new List<Client> { firstClient, secondClient };
        List<Client> resultClientList = testStylist.GetClients();

        //Assert
        Assert.AreEqual(testClientList[0].ClientName, resultClientList[0].ClientName);
    }

    // [TestMethod]
    // public void Delete_DeletesClientFromDatabase_List()
    // {
    //   //Arrange
    //   Stylist newStylist = new Stylist("test", 0);
    //   Client newClient1 = new Client("Sheila", newStylist.Id);
    //   Client newClient2 = new Client("Coral", newStylist.Id);
    //   newClient1.Save();
    //   newClient2.Save();
    //   //Act
    //   newClient1.Delete();
    //   List<Client> result = Client.GetAll();
    //   List<Client> newList = new List<Client> { newClient2 };
    //   //Assert
    //   Assert.AreEqual(newList[0].ClientName, result[0].ClientName);
    // }

  }
}
