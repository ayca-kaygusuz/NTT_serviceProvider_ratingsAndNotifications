# NTT_serviceProvider_ratingsAndNotifications
Create and implement REST APIs to be consumed by frontend applications - no authentication required. Uses C#12 .NET 8, Java, and Docker, as well as xunit and moq for unit tests.

# Notification and Rating Services

This project includes two services:
1. **Notification Service** - A Spring Boot application for managing notifications.
2. **Rating Service** - A C# application for handling ratings and notifications.

## Table of Contents

- [Notification Service](#notification-service)
  - [Features](#features)
  - [Technologies Used](#technologies-used)
  - [Setup Instructions](#setup-instructions)
  - [API Endpoints](#api-endpoints)
  - [Testing](#testing)
  - [Folder Structure](#folder-structure)
- [Rating Service](#rating-service)
  - [Setup Instructions](#rating-setup-instructions)
  - [Testing](#rating-testing)
  - [Folder Structure](#rating-folder-structure)
- [License](#license)

## Notification Service

### Features

- Add notifications with a message.
- Retrieve all notifications.
- Notifications are cleared after retrieval.

### Technologies Used

- Java
- Spring Boot
- JUnit 5
- Mockito
- Maven

### Setup Instructions

1. **Clone the Repository**

   ```bash
   git clone https://github.com/yourusername/notification-service.git
   cd notification-service
   ```

2. **Build the Project**
    - Ensure you have Maven installed, then run:
    ```bash
    mvn clean install
    ```
3. **Run the Application**
    ```bash
    mvn spring-boot:run
    ```
    - The application will start on http://localhost:8080.

### API Endpoints

1. **Add a Notification**
    - **Endpoint:** POST /notifications
    - **Parameters:** message (String): The notification message.
    - **Example Request:**
    ```bash
    curl -X POST "http://localhost:8080/notifications?message=Test Notification"
    ```
2. **Get Notifications**
    - **Endpoint:** GET /notifications
    - **Response:** A list of Notifications.
    - **Example Request:**
    ```bash
    curl -X GET "http://localhost:8080/notifications"
    ```

### Testing

1. **Unit Tests:** Unit tests are provided for the NotificationService class to ensure that notifications are added and retrieved correctly. To run the unit tests, execute:
    ```bash
    mvn test
    ```
2. **Integration Tests:** Integration tests are provided for the NotificationController class. They verify the functionality of the API endpoints. To run all tests (including unit and integration tests), execute:
    ```bash
    mvn verify
    ```

## Rating Service

The Rating Service is a .NET application for managing ratings and notifications.

### Setup Instractions
1. **Clone the Repository**
2. **Build the Project** Ensure you have .NET SDK (preferably 8 or above) installed, then run:
    ```bash
    dotnet build
    ```
3. **Run the application**
    ```bash
    dotnet run
    ```
    The application will start on http://localhost:5000.

### Testing

**Unit Tests:** Unit tests are provided for the Rating Service. To run the unit tests, execute:
    ```bash
    dotnet test
    ```
## LICENSE
This project is licensed under the GPL-3.0 license. See the LICENSE file or tab for more details. 

©️ Ayca Kaygusuz 2024