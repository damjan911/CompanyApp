# Intership Application Task (CompanyApp)

is made by Damjan Krstevski.
___

##  CompanyApp consists of six Class Libraries. That's are:

 - CompanyApp.Domain
 - CompanyApp.DataAccess
 - CompanyApp.DTOs
 - CompanyApp.Helpers
 - CompanyApp.Mappers
 - CompanyApp.Services


## CompanyApp.Domain

 We will start with Domain Models first. In the First Class Library we have two Folders. The first one is for Enums which are part of the Domain Models and the second one are basically the Models which we are 
 working on. 
 In our Application we have three Domain Models and one Abstract Class called BaseEntity. <ins> That's are :  **Company**, **Contact** *and* **Country** </ins> and they are in a Relationship each other.

### Here are the relationships between the Company, Contact, and Country entities:

 1. Company and Contact Relationship:

 The relationship between a "Company" and a "Contact" is typically a "One-to-Many" relationship. This means that one company can have multiple contacts associated with it, but each contact is associated with 
 only one company.

```
  public class Company : BaseEntity
  {
      [Required]
      [MaxLength(255)]
      public string CompanyName { get; set; }

      [Required]
      public Industry Industry { get; set; }

      public List<Contact> Contacts { get; set; }

  }

```

```
   public class Contact : BaseEntity
   {
	   [Required]
	   [MaxLength(255)]
	   public string ContactName { get; set; }

	   [Required]
	   [MaxLength(255)]
	   public JobTitle JobTitle { get; set; }

	   [Required]
	   [ForeignKey("Company")]
	   public int CompanyId { get; set; }

	   public Company? Company { get; set; }

	   public Country ?Country { get; set; }

	   [Required]
	   [ForeignKey("Country")]
	   public int CountryId { get; set; }
  }

```

 2. Contact and Country Relationship:

The relationship between a "Contact" and a "Country" is "Many-to-One" relationship. multiple contacts can be associated with a single country. This implies that many contacts share the same country.

```
 public class Contact : BaseEntity
 {
      [Required]
      [MaxLength(255)]
      public string ContactName { get; set; }

      [Required]
      [MaxLength(255)]
      public JobTitle JobTitle { get; set; }

      [Required]
      [ForeignKey("Company")]
      public int CompanyId { get; set; }

      public Company? Company { get; set; }

      public Country ?Country { get; set; }

      [Required]
      [ForeignKey("Country")]
      public int CountryId { get; set; }
  }

```

```
  public class Country : BaseEntity
  {
      [MaxLength(255)]
      public string ?CountryName { get; set; }

      public List<Contact> ?Contact { get; set; }
  }

```

## CompanyApp.DataAccess

DataAccess plays a major rule and it is a crucial component for interacting with databases which contain all CRUD Operations that we need to manipulate with our Database.
[CompanyApp.DataAccess] (https://github.com/damjan911/CompanyApp/tree/master/CompanyApp.DataAccess)

## CompanyApp.DTOs

DTOs help us to seperate the internal data model of an application from the data that is exposed through the API. This separation allows us to tailor the data sent to and received from the API endpoints to the specific needs of the Client.
For each Domain Model we additionally created DTOs where we will use them further in the Services and in the Controllers. 
[CompanyApp.DTOs] (https://github.com/damjan911/CompanyApp/tree/master/CompanyApp.DTOs)

## CompanyApp.Helpers

Helper methods help us to organize our code better. In this Class Library I have registered my DbContext, Repositories and Services in order to inject them into the Program.cs where the main application resides.
[CompanyApp.Helpers] (https://github.com/damjan911/CompanyApp/tree/master/CompanyApp.Helpers)

## CompanyApp.Mappers

Mappers allows us to make Data Transformation or to convert data from one to another format. That means that this transformation can include mapping database entities to DTOs.
[CompanyApp.Mappers] (https://github.com/damjan911/CompanyApp/tree/master/CompanyApp.Mappers)

## CompanyApp.Services

In this Class Library we have the whole Business Logic of the Application. That means that they can provide a good way to organize and manage the functionality that the API offers to Clients.
[CompanyApp.Services] (https://github.com/damjan911/CompanyApp/tree/master/CompanyApp.Services)

## CompanyApp

Controllers play a fundamental rule in our Application and they are responsible for receiving HTTP Requests from Clients and at the same time they handle properly our Requests.
[CompanyApp] (https://github.com/damjan911/CompanyApp/tree/master/CompanyApp/Controllers)








