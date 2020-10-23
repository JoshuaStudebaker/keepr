## Keepr

<img class="img-responsive" src="https://images.unsplash.com/photo-1462045504115-6c1d931f07d1?ixlib=rb-1.2.1&auto=format&fit=crop&w=1951&q=80">

Keepr is a social network that allows users to visually share and discover new interests by posting images or videos that can be "kept" in a collection by those who like the content.

> A collection(`vault`) of posts(`keeps`) with a common theme. 

Users can view the profiles of other users to see
- The users name and profile image
- Their public collection of `vaults`
- `Keeps` the user has created

### Goals

In this checkpoint students will demonstrate a working knowledge of building full-stack applications. They will utilize a VueJs frontend implementing Vuex and Vue-Router to manage the DOM. On the server side students will use a DotNet WebApi for their server, implementing the Repository pattern to communicate with their MySql database. In addition students will use Auth0 for user management and Dapper as an ORM.

### The Concepts

Keepr is a typical project where some of the basic layouts have been thought up and the data objects determined. However, implementation of this code is yet to be done. The basic idea is users can browse all of the items (aka `Keeps`) that have been posted without having to login, and post items if they are logged in. If any user wants to store a reference to any particular keep they will store it in the `vault` of their choice. Users can have many vaults, and vaults can be set as public or private.

When a user clicks on a keep from the main page the `keep` should be opened up in a more detailed view (i.e. modal see Mock) where they can then choose to add it to one of their `vault`s.

Vaults themselves are relatively straight forward. They only require a `Name`, `Description`, and `IsPrivate` properties. This object will then be used as a part of a relationship to find all the `keep`s that have been added to it. 

For example I may really like game art and thus: 

> As a user I can create a `vault` named **_Sweet Game Art_** so that I can have a collection to store the `keep`s I like.

Lastly I can view other members profiles to see all the `vault`s and `keep`s they have created *(only the public vaults of other users)*, and look at the `keep`s in each of their `vault`s.

### Where is the data?

To get started you are going to need to create some models and think about the necessary relationships. You will need to manage the users `profile`, `keep`s, `vault`s and `vaultkeep`s you will also need at least 1 view model for getting keeps by vaultId.

Users will be allowed to create `vault`s where they can organize the posts(`keep`s) of other users so they can recall the `keep`s they enjoy by looking at that particular `vault`.

In addition to creating and deleting `keep`s and `vault`s, users can add and remove `keep`s from their `vault`s

A single user can have many `vault`s but each `vault` will only belong to a single user. 

> See references below for the UML diagram breaking down properties and relationships for these models.

### Business Rules and Functionality

We want give users some credit for creating excellent `keep`s to do that you will want to set up a way to keep track of the number of times a keep has been viewed, and how many times it has been added to any vault. (as a stretch goal, when it is removed this count should be updated to go down as well).

Due to the privacy of our users, Vaults marked private may only be retrieved by the user who created the vault, there are a few places you will want to make a check on what vaults should be returned.

### Adhering to the Mock

You have been provided the following Figma to provide you the general layout. While this is not strictly required, consider that many of the design descisions (rounded corners, page layout, masonry) are all very much in line with modern design principals. While you are free to alter the theme, strict adherence to the layouts depicted in the mocks is manditory. 

- [Figma Document](https://www.figma.com/file/Uui3335TxIEXWzgp4xrX9r/Keepr?node-id=0%3A1)
- [Figma Prototype](https://www.figma.com/proto/Uui3335TxIEXWzgp4xrX9r/Keepr?node-id=1%3A53&scaling=min-zoom)


### BONUS Ideas - Sharing the fun

- `Keep`s should be tagged, allowing users find keeps by tag
- Users can create custom tags 
- Tags are not duplicated (Games,games,GAMES)
- Write a few tests for your components 80/20.
- Implement pagination or infinite scroll
- Users can extend their profile to include a bio, ect...

# Requirements

- Visitors can see all `keep`s (login not required)
- `Keep` cards are displayed in accordance to mock
	- A `keep` card includes image, title, creator avatar
	- Clicking on the creator avatar navigates to the creators profile page *(stop propagate)*
- Cards follow a mansonry layout *(bootstrap card columns OR masonry)*
- Clicking on a `keep` card opens the `keep` in a modal which adheres to mock
	- Keep Count
	- View Count
	- Keep Description
	- Keep Title
	- Keep Creator name and avatar
	- Keep Image
	- Add to vault functionality
- All users have a public profile page
- The profile page adheres to mock:
	- **Public** vaults
	- **Private** vaults if it is their own page
	- Keeps created by that user
	- Total `keep`s count
	- Total public `vault`s count
	- The users name and avatar
- Each `vault` has its own route where users can view all of the `keeps` in the vault
- On the `vault` page, if the `vault` is private and not the active users the request fails
- From the `vault` page if the user is the creator they can remove `keep`s from the `vault`
- Anytime a `keep` is `kept in a vault` the keep count is incremented
- Users can Register, login and automatically authenticated on refresh
- Create and Delete Keeps
- Create and Delete Vaults
- Users can only Delete **things they created**
- All deletes require confirmation
- Add `keeps` to `vault`s
- Remove `keeps` from `vault`s
- All API Tests pass

### Finished?

> Make sure you test it. When You are finished submit your project to the gradebook and notify your instructor

---
***UML Reference***
![reference](./References.png)
