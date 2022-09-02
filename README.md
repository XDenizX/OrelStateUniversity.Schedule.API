# Orel State University Schedule API

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)

This class library provides a client .NET implementation for interacting with the Orel State University Schedule API.

> **This library is not official.**

## Features

- Getting a list of divisions for students;
- Getting a list of courses;
- Getting a list of groups;
- Getting a schedule for a group for 7 days starting from the current moment.

## Install
You can install this package at this [link](https://www.nuget.org/packages/OrelStateUniversity.API) or using the following commands:

```
Install-Package OrelStateUniversity.API -Version 1.0.1
```
or
```
dotnet add package OrelStateUniversity.API --version 1.0.1
```
## Usage

To start working with the API, you need to create an instance of the `ScheduleApiClient` class.

For example, as follows:
```csharp
IScheduleApiClient client = new ScheduleApiClient();
```

To get a list of divisions available to students, you need to use the `GetStudentDivisionsAsync` method.

For example, as follows:
```csharp
IEnumerable<Division> divisions = await client.GetStudentDivisionsAsync();
```

To get a list of available courses for the specified division, use the `GetCoursesAsync` method.

For example, as follows:
```csharp
Division division = divisions.FirstOrDefault();
IEnumerable<Course> courses = await client.GetCoursesAsync(division.Id);
```

To get a list of all groups for the specified division on the specified course, use the `GetGroupsAsync` method.

For example, as follows:
```csharp
Course course = courses.FirstOrDefault();
IEnumerable<Group> groups = await client.GetGroupsAsync(division.Id, course.Number);
```

To get a schedule for the specified group, use the `GetScheduleAsync` method.

For example, as follows:
```csharp
Group group = groups.FirstOrDefault();
Schedule schedule = await client.GetScheduleAsync(group.Id);
```

Lessons for 7 days starting from the current moment will be available in the `Lessons` property.

For example, as follows:
```csharp
Lesson lesson = schedule.Lessons.FirstOrDefault();

// Process the information about the lesson.
```

## Non-asynchronous call
You can use all of these methods in non-synchronous projects as follows:

```csharp
Schedule schedule = client.GetScheduleAsync(group.Id)
  .GetAwaiter()
  .GetResult();
```
