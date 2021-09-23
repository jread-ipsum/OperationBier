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
> Usage Add a Brewery: POST api/Brewery URI parameters: none Body parameters:  

> NAME TYPEBreweryId integer required BreweryName string required BreweryDescription string IsStillInBusinessboolean string Address string State string ZipCode string PhoneNumber string Email string CountryOfOrigin 

> Update a Brewery: PUT api/Brewery URI parameters: none Body parameters: 

> NAME TYPEBreweryId integer required BreweryName string required BreweryDescription string IsStillInBusinessboolean string Address string State string ZipCode string PhoneNumber string Email string CountryOfOrigin 

> Delete a Brewery: DELETE api/Brewery/{id} URI parameters: NAME TYPE id integer required 

> Get all Breweries: GET api/Brewery URI parameters: none Body parameters: none 


      
## Retail



## Style

> Usage
  Add a Style:
    POST api/Style
      URI parameters: none
      Body parameters:  
      NAME                  TYPE
      StyleName             string
      Description           string
      IBU                   integer
      FoodPairing           List<string>
      CountryOfOrigin       string
      ReccomendedGlassware  string

 > Update a Style:
    PUT api/Style
      URI parameters: none
      Body parameters:
      NAME                  TYPE
      StyleName             string
      Description           string
      IBU                   integer
      FoodPairing           List<string>
      CountryOfOrigin       string
      ReccomendedGlassware  string
            
  >Delete a Style:
    DELETE api/Style/{id}
      URI parameters: 
      NAME            TYPE
      id              integer   required
  
 > Get all Styles:
    GET api/Style
      URI parameters: none
      Body parameters: none
      
