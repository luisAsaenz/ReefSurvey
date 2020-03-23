# Reef Survey Project

## About

This repository represents the source code needed to import raw reef survey data (`external/survey/1-data/*/Fish Dump.csv`)
into a normalized SQL database. The SQL connection is done using EF Core so the required database structure is reflected in
`models/`.

This repository makes use of two helper classes `Parse` and `Reader`. The former allows for CSV files to be split into an array
and the latter reads the raw reef survey data and converts the CSV files into strings.

## Configuration

1. Clone repository.
2. Create empty database using model hierarchy.
3. Update SQL Server data source in `models/ReefSurveyContext.cs`.
4. Compile and run.