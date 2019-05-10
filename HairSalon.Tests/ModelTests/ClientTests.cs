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
      string result = newClient.Name;

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
      string name01 = "Jody Han";
      string name02 = "Mindy Goh";
      Client newClient1 = new Client(name01, 1, 2);
      newClient1.Save();
      Client newClient2 = new Client(name02, 2, 3);
      newClient2.Save();
      List<Client> newList = new List<Client> { newClient1, newClient2 };

      //Act
      List<Client> result = Client.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectClientFromDatabase_Client()
    {
      //Arrange
      Client testClient = new Client("Hua-Min Rae", 0, 1);
      testClient.Save();

      //Act
      Client foundClient = Client.Find(testClient.Id);

      //Assert
      Assert.AreEqual(testClient, foundClient);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
    {
      // Arrange, Act
      Client firstClient = new Client("Lindsey Mules", 1, 2);
      Client secondClient = new Client("Lindsey Mules", 1, 2);

      // Assert
      Assert.AreEqual(firstClient, secondClient);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ClientList()
    {
      //Arrange
      Client testClient = new Client("Laura Gingham", 3, 1);

      //Act
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Client testClient = new Client("Erin Jung", 1, 2);

      //Act
      testClient.Save();
      Client savedClient = Client.GetAll()[0];

      int result = savedClient.Id;
      int testId = testClient.Id;

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Edit_UpdatesClientInDatabase_String()
    {
      //Arrange
      Client testClient = new Client("Lolo Lee", 1, 2);
      testClient.Save();
      string secondName = "Lola Lee";

      //Act
      testClient.Edit(secondName);
      string result = Client.Find(testClient.Id).Name;

      //Assert
      Assert.AreEqual(secondName, result);
    }

    [TestMethod]
    public void GetStylistId_ReturnsClientsParentStylistId_Int()
    {
      //Arrange
      Stylist newStylist = new Stylist("Sheila Moore", "Hair dying", 0);
      Client newClient = new Client("Wallace Tan", newStylist.Id, 1);

      //Act
      int result = newClient.StylistId;

      //Assert
      Assert.AreEqual(newStylist.Id, result);
    }

  }
}
