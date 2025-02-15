# OptimalRouteAPI (C#/.NET)
A REST API using .NET 6 (C#) that calculates the shortest route between two cities based on given road connections.

## Overview
This API finds the optimal route between cities using a JSON payload containing cities, roads, a start, and a destination. Then it returns the path with the shortest travel time.

## Approach
### **Algorithm**
- It efficiently finds the shortest path using **last-in-first-out (LIFO) collection**.
- It explores all possible paths.

### **API Design**
- The API follows clean architecture and SOLID principles.
- Uses dependency injection (DI) to separate concerns.
- Exposes a single `POST /optimal-route` endpoint.

## Setup & Running Locally
### **Prerequisites**
Ensure you have the following installed:
- .NET 6 SDK ([Download Here](https://dotnet.microsoft.com/en-us/download/dotnet/6.0))

### **Clone the Repository**
```sh
git clone https://github.com/norians/OptimalRouteAPI.git
cd OptimalRouteAPI
```

## Example Request & Response
### Request 
```javascript
{
  "cities": ["A", "B", "C", "D"],
  "roads": [
    {"from": "A", "to": "B", "time": 10},
    {"from": "B", "to": "C", "time": 15},
    {"from": "A", "to": "C", "time": 30},
    {"from": "C", "to": "D", "time": 5},
    {"from": "B", "to": "D", "time": 25}
  ],
  "origin": "A",
  "destination": "D"
}
```

### Response
```javascript
{
  "route": ["A", "B", "C", "D"],
  "totalTime": 30
}
```

## Areas for Improvement
While the API is functional, there are areas that can be improved for better reliability like error handling and data validation.

Before processing the request, ensure:
- All required fields exist (cities, roads, origin, and destination).
- Cities and roads contain valid data.
- No negative travel times (since time cannot be negative).
