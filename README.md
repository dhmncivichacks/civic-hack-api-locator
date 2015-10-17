# civic-hack-api-locator

A project to create an API discovery service that catalogs APIs exposing public
civic data around Wisconsin (and the US?  and the world?) that conform to common
interfaces.  Currently an early POC, feedback on the API is welcome!

http://civic-hack-api-locator.azurewebsites.net

Born at the first [Appleton Civic Hackathon!](http://dhmncivichacks.blogspot.com/2015/06/day-after-report-dhmn-civic.html)

## Todo

### Stabilize API

Some major questions/unfinished work:

* Can contracts be versioned?
* Is there any sort of support for polymorphism (contract A is a superset of contract B)?
* Add API calls for creating user accounts to manage contracts/implementations (should contracts be managed by end users or just admins?)


### Create Web Front End

* Account management
* Manage contracts/implementations
