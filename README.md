# cookie-authentication-example-aspnetcore

A Sample Application to explain how to setup Cookie Authentication with ASP.NET Core. This application works with its own user validation and password handling logic such that it works without using AspNetIdentity framework.

The Application demonstrates:

* Cookie Authentication using Cookie Middlewares
* Password management in database using a randomly generated salt and HMACSHA256 hashing
* LocalDB as a database source 
* Conditional Menu on the Navbar with Razor
* Creating cookie consent by configuring Cookie Policy

The complete demonstation of this project is explained at: https://referbruv.com/blog/posts/implementing-cookie-authentication-in-aspnet-core-without-identity
