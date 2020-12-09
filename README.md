# FiltersAndPagination

This repository provides a clean implementation of a REST API to query database objects with generic filters and paginated response.

## Domain

The goal here was to provide domain entities to be queried. I have created two entities ~~POCO's~~ called "ToDo" and "Task", both with custom properties. A "ToDo" can have multiple "Task", and a "Task" can have only one "ToDo".

## Initialization

A in-memory database will be automatically created with 150 default objects ready to be queried.

