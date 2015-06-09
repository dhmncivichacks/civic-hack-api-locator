# civic-hack-api-locator

A project to create an API discovery service that catalogs APIs exposing public civic data around Wisconsin (and the US?  and the world?) that conform to common interfaces.  Currently an early POC, feedback on the API is welcome!

Born at the first [Appleton Civic Hackathon!](http://dhmncivichacks.blogspot.com/2015/06/day-after-report-dhmn-civic.html)

[Check out a live POC!](https://microsoft-apiapp791157b06a4c498882849b12c3107a77.azurewebsites.net/swagger/ui/index)

## Todo

### Stabilize API

Some major questions/unfinished work:

* Can contracts be versioned?
* Is there any sort of support for polymorphism (contract A is a superset of contract B)?
* Should "RequestMode" (Get/PostFormUrlEncoded/PostJson) be at the Contract or Implementation level?  (If at Contract level, all implementors would have to have the same calling convention, but is that a bad thing?  Implementation level could be more confusing to implement for consumers)
* Add JsonSchema examples/validation
* Add API calls for creating user accounts to manage contracts/implementations (should contracts be managed by end users or just admins?)


### Create Web Front End

* Browse contracts/implementations
* Account management
* Manage contracts/implementations
