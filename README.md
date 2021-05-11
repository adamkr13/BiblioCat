# BiblioCat
Eleven Fifty Academy Software Development Red Badge Project

## Version
Version 1 was published with Azure on May 10, 2021.

[BiblioCat](https://bibliocat.azurewebsites.net/)

## Introduction

BiblioCat is a Web Application to aid in the crowdsourced tracking and managing of information about your favorite Authors, Books, Publishers, Series, and Conventions. With the current design, the user may create, edit, update, and delete (Authors, Books, Publishers, Series, and Conventions). Then, once those items are created, they may be added/connected to each other through specific menus dedicated to that purpose.

In the remainder of this ReadMe, an "object" is a reference to a specific Author, Book, Series, Publisher, or Convention.

## Installing / Getting started

There are not any installation requirements.

## Usage

### Register and Login

Upon initially visiting the site, you will be taken to a page to register or login.

![Front Page](/BiblioCat.WebMVC/Content/Assets/FrontPage.jpg)

To Register, fill out the below fields. Your password must be at least six characters, contain an uppercase character, a lowercase character, a digit, and a non-alphanumeric character. The registration process automatically logs you in.

![Register Page](/BiblioCat.WebMVC/Content/Assets/RegisterPage.jpg)

If you are returning to the site after already registering, go to the Log in Page and fill enter your information there.

![Login page](/BiblioCat.WebMVC/Content/Assets/LoginPage.jpg)

### Navigation

Once logged in, you will be taken to the front page where you will have the option of using the navigation bar at the top

![Nav Bar](/BiblioCat.WebMVC/Content/Assets/NavBar.jpg)

or the buttons in the main section of the page

![Main Page](/BiblioCat.WebMVC/Content/Assets/MainPage.jpg)

to navigate to the Author, Book, Series, Publisher, and Convention pages where you will be able to manipulate those items.

On any page, you can use the navigation bar on the top to go to a specific list page.

If you are using a device with a narrower screen, you can reveal these NavBar options by clicking on the hamburger menu on the top right of the screen.

![Hamburger Menu](/BiblioCat.WebMVC/Content/Assets/HamburgerMenu.jpg)

### Adding an Author, Book, Series, Publisher, or Convention

Here is an example of a list page.

![List Page](/BiblioCat.WebMVC/Content/Assets/ListPage.jpg)

Click on the Add (Author, Book, etc) Button and you will be taken to a page to enter the information for that object.

From that page, you can enter the information and click the Create Button to Create the new object or you can go back to the list page.

![Add Author](/BiblioCat.WebMVC/Content/Assets/AddAuthor.jpg)

### Object Options

On the list page (see example above), on the right of the object, there is a menu of options that pertain to that specific object.

![Object Options](/BiblioCat.WebMVC/Content/Assets/ObjectOptions.jpg)

#### Editing an Object

On the list page, clicking on "Edit" takes you to the object edit page where you can edit the information for that object and save the changes or go back to the list page without saving the changes.

![Object Options](/BiblioCat.WebMVC/Content/Assets/EditAuthor.jpg)

#### The Details Page

Click on "Details" takes you to the object details page where you can view information about that object that may not be shown in the list page. This page also has all of the options available for each object in the list page as well as a button to go back to the list page.

![Author Detail](/BiblioCat.WebMVC/Content/Assets/AuthorDetail.jpg)

#### Deleting an Object

On the list page, clicking on "Delete" takes you to the object delete page where you can delete an object. Clicking on "Delete" will delete the object.

![Author Delete](/BiblioCat.WebMVC/Content/Assets/AuthorDelete.jpg)

### Connecting Objects
- For this example we will be adding books to an author. This process is the same for any of the connections that may be made with these objects with the exception of adding Publishers. 

Once you have added, as an example, an author and a book, you may connect these two objects.

On the list page, in the menu to the right of the object of interest, click on the thing you want to do. In this case, it is "Add Books".

That will take you to a page where you may select from a list of all the books and add them to the author. Select the books you want to add by clicking on their check box and then click "Add Books" and they will be added to the Author.

![Add Books To Author](/BiblioCat.WebMVC/Content/Assets/AddBooksToAuthor.jpg)



