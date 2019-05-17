using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {
    public void Dispose()
    {
      Client.ClearAll();
    }

    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;port=3306;database=reese_lee_test;";
    }

    [TestMethod]
    public void ClientConstructor_CreatesInstanceOfClient_Client()
    {
      Client newClient = new Client("test", 1);
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Shelley Miles";
      Client newClient = new Client(name, 1);

      //Act
      string result = newClient.ClientName;

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ClientList()
    {
      //Arrange
      List<Client> newList = new List<Client> { };

      //Act
      List<Client> result = Client.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsClients_ClientList()
    {
      //Arrange
      Client newClient1 = new Client("Lydia Goh", 1);
      newClient1.Save();
      Client newClient2 = new Client("Nancy Wing", 2);
      newClient2.Save();
      List<Client> newList = new List<Client> { newClient1, newClient2 };

      //Act
      List<Client> result = Client.GetAll();

      //Assert
      Assert.AreEqual(newList[0].ClientName, result[0].ClientName);
    }

    [TestMethod]
    public void Find_ReturnsCorrectClientFromDatabase_Client()
    {
      //Arrange
      Client testClient = new Client("Hua-Min Rae", 0);
      testClient.Save();

      //Act
      Client foundClient = Client.Find(testClient.Id);

      //Assert
      Assert.AreEqual(testClient.ClientName, foundClient.ClientName);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
    {
      // Arrange, Act
      Client firstClient = new Client("Lindsey Mules", 1);
      Client secondClient = new Client("Lindsey Mules", 1);

      // Assert
      Assert.AreEqual(firstClient, secondClient);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ClientList()
    {
      //Arrange
      Client testClient = new Client("Laura Gingham", 1);

      //Act
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      //Assert
      Assert.AreEqual(testList[0].ClientName, result[0].ClientName);
    }

    // [TestMethod]
    // public void Save_AssignsIdToObject_Id()
    // {
    //   //Arrange
    //   Client testClient = new Client("Erin Jung", 2);
    //
    //   //Act
    //   testClient.Save();
    //   Client savedClient = Client.Find(testClient.Id);
    //
    //   int result = savedClient.Id;
    //   int testId = testClient.Id;
    //
    //   //Assert
    //   Assert.AreEqual(testId, result);
    // }

    [TestMethod]
    public void Edit_UpdatesClientInDatabase_String()
    {
      //Arrange
      Client testClient = new Client("Lolo Lee", 2);
      testClient.Save();
      string secondName = "Lola Lee";

      //Act
      testClient.Edit(secondName);
      string result = Client.Find(testClient.Id).ClientName;

      //Assert
      Assert.AreEqual(secondName, result);
    }

    [TestMethod]
    public void GetStylistId_ReturnsClientsParentStylistId_Int()
    {
      //Arrange
      Stylist newStylist = new Stylist("Sheila Moore", 0);
      Client newClient = new Client("Wallace Tan", newStylist.Id);

      //Act
      int result = newClient.StylistId;

      //Assert
      Assert.AreEqual(newStylist.Id, result);
    }

    [TestMethod]
    public void Delete_DeletesClientFromDatabase_List()
    {
      //Arrange
      Stylist newStylist = new Stylist("test", 0);
      Client newClient1 = new Client("Sheila", newStylist.Id);
      Client newClient2 = new Client("Coral", newStylist.Id);
      newClient1.Save();
      newClient2.Save();
      //Act
      newClient1.Delete();
      List<Client> result = Client.GetAll();
      List<Client> newList = new List<Client> { newClient2 };
      //Assert
      Assert.AreEqual(newList[0].ClientName, result[0].ClientName);
    }
  }
}
