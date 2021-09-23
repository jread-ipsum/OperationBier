# OperationBier

Mission Statement
  We want the people to find the beers they love, wherever they live.  This 
BeerFinder app will allow users to search for specific beers and find where 
they are sold, who brewed the beer, and gives specific info on certain brews 
from around the world.

Installation
  application built using Vs Studio 2019
  ASP.NET Web Application(.NetFramework)
  Nuget Packages used include:
    For entire solution:
      EntityFramework(EF6)6.4.4
      Microsoft.AspNet.Identity.EntityFramework 2.2.3
    For projects OperationBier.Data and OperationBierAPI:
      Microsoft.AspNet.Identity.Owin 2.2.3
      Microsoft.AspNet.WebApi.Owin 5.2.7
      
 ## Beer
   
> Usage
  Add a Beer:
    POST api/Beer
      URI parameters: none
      Body parameters:  
      NAME            TYPE
      BeerName        string    required
      ABV             double    required
      IsRecommended   boolean
      BreweryId       integer

 > Update a Beer:
    PUT api/Beer
      URI parameters: none
      Body parameters:
      NAME            TYPE
      BeerId          integer   required
      BeerName        string    required
      ABV             double    required
      IsRecommended   boolean 
      BreweryId       integer
      
 > Update/Add Beer Retailers: 
    PUT api/Beer/Retailers
      URI parameters: none
      Body parameters:
      NAME            TYPE
      BeerId          integer   required
      RetailId        integer   required
      
  >Delete a Beer:
    DELETE api/Beer/{id}
      URI parameters: 
      NAME            TYPE
      id              integer   required
  
 > Get all Beers:
    GET api/Beer
      URI parameters: none
      Body parameters: none
  
  > Get Beer Details and Retailers by Id:
    GET api/Beer/{id}
      URI parameters: 
      NAME            TYPE
      id              integer   required
      
  > Get Beer Details and Retailers by Name:
    GET api/Beer/Name/{name}
      URI parameters:
      NAME            TYPE
      name            string    required
      
  > Get Recommended Beers:
    GET api/Beer/Recommended
      URI parameters: none
      Body parameters: none
      
 > Get all Beers with specified ABV:
    GET api/Beer/abv/{abv}
      URI parameters:
      NAME            TYPE
      abv             double    required
      
 >  Get all Beers with ABV higher than specified:
    GET api/Beer/abvgreater/{abv}
      URI parameters:
      NAME            TYPE
      abv             double    required 
    
## Brewery



      
## Retail



## Style
      
