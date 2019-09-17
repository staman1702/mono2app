# mono2app
What is your test project 

 
 

Summary: develop a minimalistic application of your choice by following technologies and concepts mentioned above and requirements defined below. Note that we proposed a Vehicle related application, but you can choose anything you prefer.  

 

Requirements 

·         Create a database with following elements 

·         VehicleMake (Id,Name,Abrv) e.g. BMW,Ford,Volkswagen, 

·         VehicleModel (Id,MakeId,Name,Abrv) e.g. 128,325,X5 (BWM),  

·         Create the solution (back-end) with following projects and elements 

·         Project.Service 

·         EF models for above database tables 

·         VehicleService class - CRUD for Make and Model (Sorting, Filtering & Paging) 

·         Front-end framework (Angular, AngularJS, ReactJS)  

·         Make administration view (CRUD with Sorting, Filtering & Paging) 

·         Model administration view (CRUD with Sorting, Filtering & Paging) 

·         Filtering by Make 

·         Create multi-layer architecture for the project (back-end) 

·         Project.DAL 

·         Project.Common 

·         Project.Model.Common 

·         Project.Model 

·         Project.Repository.Common 

·         Project.Repository 

·         Project.Repository.Tests 

·         Project.Service.Common 

·         Project.Service 

·         Project.Service.Tests 

·         Project.WebAPI 

·         Project.WebAPI.Tests 

·         Create Angular application (front-end) that will connect to back-end 

·         This should be a separate project or solution 

·         Unit Tests  

·         create Unit Tests for vehicle model service 

·         Please use xUnit, Moq and FluentAssertions  

 
Implementation details  

·         async/await should be enforced in all layers (async all the way) 

·         all classes should be abstracted (have interfaces so that they can be unit tested) 

·         IoC (Inversion of Control) and DI (Dependency Injection) should be enforced in all layers (constructor injection preferable)  

·         Ninject DI container should be used (https://github.com/ninject/ninject/wiki) 

·         Mapping should be done by using AutoMapper (http://automapper.org/) 

·         Create DAL project using EF 6 or above with Code First approach (EF Power Tools can be used)    

·         Project.Common should be cross-cutting project containing utility classes 

·         *.Common projects should contain contracts (interfaces) for layers 

·         Repository project should implement the following 

·         Generic repository - http://www.codeproject.com/Articles/838097/CRUD-Operations-Using-the-Generic-Repository-Pat  

·         Unit Of Work -  https://gist.github.com/khorvat/2b1bf27f0047f62fdb60 & https://gist.github.com/khorvat/dabbb408f7419235efd8 http://www.codeproject.com/Articles/581487/Unit-of-Work-Design-Pattern  

·         Service project 

·         use composition pattern with repositories -inject them through the constructor - http://en.wikipedia.org/wiki/Composition_over_inheritance  

·         service methods should only use model contracts (interfaces) as input and output parameters 

·         WebAPI project 

·         this is DI composition root so you should install Ninject here 

·         use controllers with async methods 

·         return proper Http status codes 

·         Angular 

·         enforce the following folder structure - https://angular.io/docs/ts/latest/guide/style-guide.html#04-06  

·         enforce the following naming conventions - https://github.com/johnpapa/angular-styleguide/blob/master/a2/README.md   
