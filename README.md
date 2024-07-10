# Depth Charts

## Requirements

* .NET 8

## Running examples and tests

To run the examples

`dotnet run --project .\DepthCharts.Examples\`

The examples cover:
* Printing a depth chart
* How to support multiple teams and sports
* How to create depth charts with type-safe positions which makes use of the generic implementation of the depth chart

To run the tests

`dotnet test`

## Assumptions/Design decisions
* Adding players to a depth chart must be done in order
    * This made the data structure simpler as I could use a list for players rather than a different option to allow out of order inserts

* The depth chart data structure is not thread-safe
    * This could be resolved with lock statements or ReaderWriterLockSlim if necessary