# Transport Company SW

## Software Requirements Specification

**Team “Number One”**

**Version 0.2**

---

### Table of contents


1. [Introduction](#1-introduction)
   1. Purpose
   2. Document conventions
   3. Contact information/SRS team members
2. [Overall Description](#2-overall-description)
   1. Product functions
   2. User classes and characteristics
   3. Operating environment
   4. User environment
   5. Design/implementation constraints
   6. Assumptions and dependencies
3. [External Interface Requirements](#3-external-interface-requirements)
   1. User interfaces
   2. Hardware interfaces
   3. Software interfaces
   4. Communication protocols and interfaces
4. [System Features](#4-system-features)
   1. System feature A
   2. Functional requirements
   3. System feature B
5. [Other Non-Functional Requirements](#5-other-non-functional-requirements)
   1. Performance requirements
   2. Safety requirements
   3. Security requirements
   4. Software quality attributes


---

## 1. Introduction

#### 1.1. Purpose

The purpose of this document is to provide a full description of a
Transport Management System. A Transportation Management System is a
software system which is created to manage transportation operations and
ensure better service. Program should decrease transportation time, fuel
cost and increase customer satisfaction. 

#### 1.2. Document conventions
When writing this SRS, the following terminologies are used:


* **TCP** - The Transmission Control Protocol is one of the main
  protocols of the Internet protocol suite.
* **FIFO** - an acronym for first in, first out, a method for organizing
  and manipulating a data buffer, where the oldest (first) entry, or
  'head' of the queue, is processed first.
* **GSM** - is a standard developed by the European Telecommunications
  Standards Institute to describe the protocols for second-generation
  digital cellular networks used by mobile devices such as mobile
  phones.
* **NFC** - Near-field communication is a set of communication protocols
  that enable two electronic devices, one of which is usually a portable
  device such as a smartphone, to establish communication by bringing
  them within 4 cm (1.6 in) of each other.
* **GPS** - The Global Positioning System is a space-based
  radionavigation system owned by the United States government and
  operated by the United States Air Force.
* **RFID** - Radio-frequency identification uses electromagnetic fields
  to automatically identify and track tags attached to objects.
* QR code - a machine-readable optical label that contains information
  about the item to which it is attached.
* **BSON** - BSON /ˈbiːsən/ is a computer data interchange format used
  mainly as a data storage and network transfer format
* **JSON** - an open-standard file format that uses human-readable text
  to transmit data objects consisting of attribute–value pairs and array
  data types (or any other serializable value).
* **Socket** - an end-point in a communication across a network or the
  Internet
* **HTTP** - Hypertext Transfer Protocol is an application protocol for
  distributed, collaborative, and hypermedia information systems.
* **COM** - name of the serial port interface on IBM PC-compatible
  computers.


#### 1.3. Contact information/SRS team members
1. PM: Daniil Lashin (d.lashin@innopolis.ru)
2. CA: Gheorghe Pinzaru (g.pinzaru@innopolis.ru)
3. Albert Sakhapov (a.sakhapov@innopolis.ru)
4. Irina Erofeeva (i.erofeeva@innopolis.ru)
5. Alena Zhabina (a.zhabina@innopolis.ru)
6. Anton Prokopev (a.prokopev@innopolis.ru)

---

## 2. Overall Description

#### 2.1 Product functions
1. Monitor and track parcels lifecycle
2. Monitor and track delivery operation
3. Monitor traffic and critical conditions and provide warning and
   alternatives
4. Manage criticality and accidents involving delivery
5. Generate activity reports
6. Define operators schedules and turnover
7. Monitor and reporting on stocking areas

#### 2.2 User classes and characteristics
1. International and local manufacturing companies.
2. Legally capable population from 16 to 60+ age with e-wallet.
3. Truck drivers as employees.

#### 2.3 Operating environment

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Base: Main Control room with 3
servers, 20 PC based stations with multiple screens. Local High speed
bus.

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 3 Level 2 Control rooms 2 servers 5
PC based stations stations with multiple screens. High speed COMs
(Fiber) with Main CR.

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 500 remote terminal (Android). 4G
(up 60%), GSM (up 95%), 50 terminal have parallel Satcom.

#### 2.4 User environment

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Web client based on WEB 2.0,
Android and Desktop application.

#### 2.5 Design/implementation constraints

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; The challenges in developing this
product consist the most in the limitation of the internet speed on
remote terminals. Due to the speed of GSM 115.2Kbit/s and average speed
of satlink of 1Mbit/s + latency of 638 ms we need to delimit the
information which will be processed on the server and terminal to send
less data to the server. It is required to use some protocols over TCP
to ensure data security and data safety. Data will be sent as encrypted
text, because binary packets are more expensive in requirements of
internet. Sometime wireless internet can not be accessible so,
information need to be available offline and synced with the server when
internet appear, sync must be in FIFO and timestamped.

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Because tracking each package
manually is too hard, it will be necessary to mark all packages with
unique identifier and to track enter and exit of package from the
transport or office. There are multiple methods of fast tracking each
package, the best will be to have an NFC reader on the terminals and
attach RFID to each package. If NFC is not available or too expensive
for the company there is a solution to print QR codes and attach them to
each package and terminal will have a camera to read.

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; App must do a lot of action
automatically, because there are a lot of packages and personal of the
company may not be in time to manually input data for each them.

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Each terminal must have GPS, so on
the map live all products which have status entered into the transport
can be tracked and analytics can create estimation on delivery.

---

## 3. External Interface Requirements


#### 3.1 User interfaces 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; User interfaces in both Desktop and Mobile platforms should follow Material
Design Principles introduced by Google (https://material.io/).


#### 3.2 Software interfaces 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
Software interfaces should be standardized to JSON format. In cases of
slow connection it better to use BSON (http://bsonspec.org/) for data
compression and GZIP for text compression.


#### 3.3 Communication protocols and interfaces
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Communications will be based on
HTTP and Socket protocols.

---

## 4. System Features


| Role             | Description                                                                          |
|:-----------------|:-------------------------------------------------------------------------------------|
| Software User    | All the users of software.                                                           |
| Customer         | Uses transport company services to send or receive parcels.                          |
| Company operator | Communicates with customers, drivers and company managers. Solves delivery problems. |
| Company manager  | Defines employees’ schedule and generates activity reports.                          |
| Stock-manager    | Controls filling of a warehouse.                                                     |
| Driver           | Delivers parcels.                                                                    |


### Features:


#### 1. Different types of user should have separate login accounts

| Requirement   | #1                                                                                                                                     |
|:--------------|:---------------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Software User                                                                                                                          |
| Description   | Different types of user should have separate login accounts.                                                                           |
| Rationale     | When user logs into account, he/she may use functions that are allowed to his/her type of account.                                     |
| Fit Criterion | Main page asks user to enter his/her login and password. Then on clicking on “Sign In” button, user will be redirected to his account. |
| Dependencies  | Independent                                                                                                                            |

---

#### 2.  Customers shall be able to monitor their parcels using track code

| Requirement   | #2                                                                                                 |
|:--------------|:---------------------------------------------------------------------------------------------------|
| Actor         | Customer                                                                                           |
| Description   | Customers will enter track code to monitor their parcels’ state.                                   |
| Rationale     | This will enable customers to know where his/her parcel is.                                        |
| Fit Criterion | Customer will enter track number and then system will show him/her state and tracking information. |
| Dependencies  | Independent                                                                                        |

---

#### 3.  Company operator shall be able to monitor customer’s parcel state

| Requirement   | #3                                                                                                                    |
|:--------------|:----------------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                                      |
| Description   | Company Operator will enter customer’s track number to monitor customer’s parcel state.                               |
| Rationale     | This will let Company Operator to provide first-hand information to customers.                                        |
| Fit Criterion | Company Operator will enter customer’s track number and then system will show him/her state and tracking information. |
| Dependencies  | Independent                                                                                                           |

---

#### 4.  Driver shall be able to receive weather warnings 

| Requirement  | #4                                                                                                 |
|:-------------|:---------------------------------------------------------------------------------------------------|
| Actor        | Driver                                                                                             |
| Description  | Driver will receive weather warnings.                                                              |
| Rationale    | This will prepare drivers for weather conditions.                                                  |
| FitCriterion | Driver’s geolocation and internet connection is enabled. If weather changes, warning will be sent. |
| Dependencies | Independent                                                                                        |

---

#### 5. Company Operator shall be able to change driver’s route

| Requirement   | #5                                                                                          |
|:--------------|:--------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                            |
| Description   | Company Operator will change driver’s route by adding or removing company offices to route. |
| Rationale     | This will enable Company Operator to choose a new convenient route for driver.              |
| Fit Criterion | Operator will click “Add” or “Remove” buttons, then system will send new route to driver.   |
| Dependencies  | Independent                                                                                 |


#### 6. Company Operator shall be able to monitor road traffic

| Requirement   | #6                                                                                                                |
|:--------------|:------------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                                  |
| Description   | Company Operator will monitor road traffic in the entered city.                                                   |
| Rationale     | This will enable Company Operator to warn drivers or give them another way to destination in case of traffic jam. |
| Fit Criterion | Operator will enter city and click “Traffic” button, then system will show map with traffic jams.                 |
| Dependencies  | Independent                                                                                                       |


#### 7. Company Operator shall be able to find the nearest repair center 

| Requirement   | #7                                                                                                                                                                                                      |
|:--------------|:--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                                                                                                                        |
| Description   | Company Operator will find the nearest repair center in case of accident.                                                                                                                               |
| Rationale     | This will enable Company Operator to find repair centers that can fastly mend truck so that parcels can reach destination on time.                                                                      |
| Fit Criterion | Driver’s geolocation should be enabled. Operator will receive “accident signal”, click “Nearest Repair Centers” button and then system will show all the repair centers that are closest to the driver. |
| Dependencies  | Independent                                                                                                                                                                                             |


#### 8. Company Operator shall be able to call repair center 

| Requirement   | #8                                                                                                                                                                 |
|:--------------|:-------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                                                                                   |
| Description   | Company Operator will call the repair center from the list of the nearest repair centers.                                                                          |
| Rationale     | This will enable Company Operator to fastly contact repair center that can mend truck so that parcels can reach destination on time.                               |
| Fit Criterion | Repair Center should be in the list of the nearest repair centers. Operator will click “Call” button and then system will connect operator with the repair center. |
| Dependencies  | 7                                                                                                                                                                  |


#### 9. Company Operator shall be able to call replacement truck

| Requirement   | #9                                                                                                          |
|:--------------|:------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                            |
| Description   | Company Operator will call replacement truck in case of accident.                                           |
| Rationale     | This will enable Company Operator to replace damaged truck so that company can deliver parcels on time.     |
| Fit Criterion | Operator will click “Call Free Driver” and system will contact operator with the nearest free truck driver. |
| Dependencies  | Independent                                                                                                 |


#### 10. Driver shall be able to receive the shortest way to destination

| Requirement   | #10                                                                                                               |
|:--------------|:------------------------------------------------------------------------------------------------------------------|
| Actor         | Driver                                                                                                            |
| Description   | Driver will receive the shortest way to destination.                                                              |
| Rationale     | This will enable driver to deliver parcels on time. Fit                                                           |
| Fit Criterion | When driver moves out, he should click “Get the Way” button and then system will show him the way to destination. |
| Dependencies  | Independent                                                                                                       |


#### 11. Company Manager shall be able to create reports

| Requirement   | #11                                                                                                                                                                                |
|:--------------|:-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Company Manager                                                                                                                                                                    |
| Description   | Company Manager will generate activity report.                                                                                                                                     |
| Rationale     | This will enable Company Manager to store full documentation about employees and company activities.                                                                               |
| Fit Criterion | Company Manager will press “Create Report” button, system will show him/her report forms. After filling them manager will press ”Create” button and then report will be generated. |
| Dependencies  | Independent                                                                                                                                                                        |


#### 12. Company Manager shall be able to create employee’s schedule

| Requirement   | #12                                                                                                                                                                                       |
|:--------------|:------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Company Manager                                                                                                                                                                           |
| Description   | Company Manager will create employee’s schedule.                                                                                                                                          |
| Rationale     | This will enable Company Manager to manage the time each employee works.                                                                                                                  |
| Fit Criterion | Company Manager will press “Create Schedule” button, system will show him/her schedule tables. After filling them manager will press ”Create” button and then schedule will be generated. |
| Dependencies  | Independent                                                                                                                                                                               |


#### 13. Stock Manager shall be able to monitor stocking areas 

| Requirement   | #13                                                                                                                                                             |
|:--------------|:----------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Stock Manager                                                                                                                                                   |
| Description   | Stock Manager will check stocking areas on space availability.                                                                                                  |
| Rationale     | This will enable Stock Manager to manage space in the warehouse.                                                                                                |
| Fit Criterion | Stock Manager will request information about parcels in the warehouse by clicking button and  then system will provide this information in the form of a table. |
| Dependencies  | Independent                                                                                                                                                     |


#### 14. Stock Manager shall be able to change the state of parcels in the stock

| Requirement   | #14                                                                                                                                                          |
|:--------------|:-------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Stock Manager                                                                                                                                                |
| Description   | Stock Manager will change the state of parcels in the stock.                                                                                                 |
| Rationale     | This will enable Stock Manager to                                                                                                                            |
| Fit Criterion | Stock Manager will change state by clicking “Change state” button and choosing right state, then system will change parcel’s state and notify Stock Manager. |
| Dependencies  | Independent                                                                                                                                                  |

#### 15. Company Operator shall be able to add new parcel into the system

| Requirement   | #15                                                                                                     |
|:--------------|:--------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                        |
| Description   | Company Operator will add new parcel into the system.                                                   |
| Rationale     | This will be the starting point of a parcel through the system                                          |
| Fit Criterion | Company Operator will add a new parcel into the system with destination point and receiver information. |
| Dependencies  | Independent                                                                                             |

#### 16. Company Operator will select a route for parcel shipping

| Requirement   | #16                                                                                           |
|:--------------|:----------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                              |
| Description   | Company Operator will select most convinent route for parcel.                                 |
| Rationale     | Based on delivery requirements system will generate valid routes and operator will select     |
| Fit Criterion | Company Operator will select a route and the route will be available into parcel information. |
| Dependencies  | Parcel Management                                                                             |

#### 17. Company Operator will view in real time expected time of delivery

| Requirement   | #17                                                                           |
|:--------------|:------------------------------------------------------------------------------|
| Actor         | Company Operator                                                              |
| Description   | Company Operator will have possibility to analyze expected time of delivery.  |
| Rationale     | Based on location system will give a prediction on remaining time to deliver  |
| Fit Criterion | Company Operator will have valid information based on prediction of delivery. |
| Dependencies  | Parcel                                                                        |

#### 18. Company Operator will view in real weather forecast and prediction 

| Requirement   | #18                                                                                                                |
|:--------------|:-------------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                                   |
| Description   | Company Operator will have possibility to check weather forecast on every point on the map.                        |
| Rationale     | Based on location system will give a prediction of forecast in the region at the predicted time of parcel location |
| Fit Criterion | Company Operator will have weather forecast to all location where system should work .                             |
| Dependencies  | Weather Module                                                                                                     |

#### 19. Company Operator will see in real time traffic congestion

| Requirement   | #19                                                                                                                        |
|:--------------|:---------------------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                                           |
| Description   | Company Operator will have possibility to view traffic on the map and drivers positions.                                   |
| Rationale     | Based on custom services system will show traffic on the map and drivers positions to change route to make delivery faster |
| Fit Criterion | Company Operator will have a map with traffic in all available regions .                                                   |
| Dependencies  | Map                                                                                                                        |

#### 20. Company Operator will activate order dispatch

| Requirement   | #20                                                                              |
|:--------------|:---------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                 |
| Description   | Company Operator will activate order dispatch.                                   |
| Rationale     | Order should be activated only when it is acknowledged by the delivery operators |
| Fit Criterion | Company Operator will have a button to activate order into the system .          |
| Dependencies  | Map                                                                              |

#### 21. Customer will have possibility to see expected delivery date

| Requirement   | #21                                                                        |
|:--------------|:---------------------------------------------------------------------------|
| Actor         | Customer                                                                   |
| Description   | Customer will have ability to see expected delivery date.                  |
| Rationale     | Customers are interested to see delivery date to wait for the parcel       |
| Fit Criterion | On tracking page will be a field which will show expected time to deliver. |
| Dependencies  | Parcel                                                                     |

#### 22. Customer will have possibility to select custom delivery time and date

| Requirement   | #22                                                                                   |
|:--------------|:--------------------------------------------------------------------------------------|
| Actor         | Customer                                                                              |
| Description   | Customer will select the most convinent time for delivery.                            |
| Rationale     | For home delivery customer should select time when he will be available to receive it |
| Fit Criterion | User will input on the personal page of the delivery time and date of delivery.       |
| Dependencies  | Parcel                                                                                |

#### 23. Company Operator should add and change custom delivery time and date

| Requirement   | #23                                                                                                                    |
|:--------------|:-----------------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                                       |
| Description   | Company Operator have a form to enter custom dates and time to deliver.                                                |
| Rationale     | For home delivery Company Operator should be able to change delivery time and date if customer ask for it              |
| Fit Criterion | On delivery page Company Operator will change time and date, driver will receive a notification with new information . |
| Dependencies  | Parcel                                                                                                                 |

#### 24. Company Operator should add and change custom delivery time and date

| Requirement   | #24                                                                                                                    |
|:--------------|:-----------------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                                       |
| Description   | Company Operator have a form to enter custom dates and time to deliver.                                                |
| Rationale     | For home delivery Company Operator should be able to change delivery time and date if customer ask for it              |
| Fit Criterion | On delivery page Company Operator will change time and date, driver will receive a notification with new information . |
| Dependencies  | Parcel                                                                                                                 |

#### 25. Company Operator will close the order only when the confirmation from the client will be received

| Requirement   | #25                                                                                                                                  |
|:--------------|:-------------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                                                     |
| Description   | Company Operator will complete order when driver will give the confirmation document from customer.                                  |
| Rationale     | To avoid lost parcels and unsatisfied clients parcel should be marked as delivered only when customer signs the document of delivery |
| Fit Criterion | Company Operator should manually confirm order when document is received                                                             |
| Dependencies  | Parcel                                                                                                                               |


#### 26.  Company Operator shall be able to change the state of parcels along the route

| Requirement   | #26                                                                                                                                                                                                          |
|:--------------|:-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                                                                                                                             |
| Description   | Company Operator will change the state of parcels along the route.                                                                                                                                           |
| Rationale     | This will enable customers to track state of parcels along the route                                                                                                                                         |
| Fit Criterion | Company Operator will change state by clicking “Change state” button and choosing right state, then system will change parcel’s state, notify Company Operator and send appropriate message to the customer. |
| Dependencies  | Independent                                                                                                                                                                                                  |


#### 27.  Company Operator shall be able to check the timeliness at the planned points along the route

| Requirement   | #27                                                                                                                                            |
|:--------------|:-----------------------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                                                               |
| Description   | Company Operator will check the timeliness at the planned points along the route.                                                              |
| Rationale     | This will enable Company Operator to understand that something has happened, take timely measures and warn the customer about possible delays. |
| Fit Criterion | Company Operator will request information about location of delivery operator in time when he/she should be at the planned points.             |
| Dependencies  | Independent                                                                                                                                    |


#### 28.  Company Operator shall be able to contact delivery operator

| Requirement   | #28                                                                                                             |
|:--------------|:----------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                                |
| Description   | Company Operator will contact delivery operator.                                                                |
| Rationale     | This will enable Company Operator to provide delivery operator real time support.                               |
| Fit Criterion | Company Operator will contact delivery operator by clicking “Contact” button and then system will connect them. |
| Dependencies  | Independent                                                                                                     |


#### 29.  Company Operator shall be able to generate a special attention message in case of delays

| Requirement   | #29                                                                                                                                                                                          |
|:--------------|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                                                                                                             |
| Description   | Company Operator will generate a special attention message in case of delays.                                                                                                                |
| Rationale     | This will let customers to receive first-hand information about their parcels and not to worry about delays.                                                                                 |
| Fit Criterion | If there is delay in delivery, Company Operator will click “Create Attention Message”, write message and the send by clicking “Send” button. System will send this message to the customers. |
| Dependencies  | Dependent on requirement 27                                                                                                                                                                  |

#### 30.  Customer shall able be create a plan for delivery

| Requirement   | #30                                                                                                     |
|:--------------|:--------------------------------------------------------------------------------------------------------|
| Actor         | Customer                                                                                                |
| Description   | Customer will plan delivery of parcels.                                                                 |
| Rationale     | This will allow customer create a plan for delivery.                                                    |
| Fit Criterion | Customer create path through company’s offices. Could be chosen by maps or typing addresses of offices. |
| Dependencies  | Independent                                                                                             |

#### 31.  Company operator shall able to check correctness of input data

| Requirement   | #31                                                                                                                                                                                                     |
|:--------------|:--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                                                                                                                        |
| Description   | Company operator will check for correctness the data from user’s plan.                                                                                                                                  |
| Rationale     | This will allow company operator accept or reject delivery plan.                                                                                                                                        |
| Fit Criterion | Company operator will receive orders from users and check its correctness by clicking on buttons “Approve” and “Reject”. The owner of order will be notified about operator’s decision by notification. |
| Dependencies  | Independent                                                                                                                                                                                             |


#### 32.   Company operator shall able to change state of orders

| Requirement   | #32                                                                                                                            |
|:--------------|:-------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                                               |
| Description   | Company operator will change state of the order after checking for correctness.                                                |
| Rationale     | This will allow company operator change state of order.                                                                        |
| Fit Criterion | Company operator will be able to change state of order by clicking “Change state” and choosing a state from the drop-down box. |
| Dependencies  | Independent                                                                                                                    |


#### 33.   Customer shall able to assess the delivery

| Requirement   | #33                                                                                                                  |
|:--------------|:---------------------------------------------------------------------------------------------------------------------|
| Actor         | Customer                                                                                                             |
| Description   | Customer can assess the delivery process at the end.                                                                 |
| Rationale     | This will allow a customer to give a grade/feedback for delivery process.                                            |
| Fit Criterion | Customer can leave feedback after receiving the parcel by clicking on “Leave Rating” and leave a message and  grade. |
| Dependencies  | Independent                                                                                                          |


#### 34.   Customer shall able to choose one of the delivery time options

| Requirement   | #34                                                                                                         |
|:--------------|:------------------------------------------------------------------------------------------------------------|
| Actor         | Customer                                                                                                    |
| Description   | Customer will choose the delivery time options.                                                             |
| Rationale     | This will allow a customer to choose how long the parcel will be delivered.                                 |
| Fit Criterion | Customer can choose delivery time by clicking on the drop-down box and choose on of the predefined options. |
| Dependencies  | Independent                                                                                                 |


#### 35.   Company operator shall able to choose one of the type of transport vector.

| Requirement   | #35                                                                                                                            |
|:--------------|:-------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                                               |
| Description   | Company operator will choose the type of transport vector.                                                                     |
| Rationale     | This will allow a Company operator to choose the certain type of transport vector.                                             |
| Fit Criterion | Company operator can choose type of transport vector by clicking on the drop-down box and choose on of the predefined options. |
| Dependencies  | Independent                                                                                                                    |


#### 36.   Company operator shall able to choose possible route for delivery.

| Requirement   | #36                                                                                                           |
|:--------------|:--------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                              |
| Description   | Company operator will choose the route.                                                                       |
| Rationale     | This will allow a Company operator to choose the certain route for delivery.                                  |
| Fit Criterion | Company operator can choose route for delivery by marking points on the map or inputting addresses of points. |
| Dependencies  | Map API                                                                                                       |

#### 37.   Customer shall be able to confirm parcel receiving.

| Requirement   | #37                                                                                                                     |
|:--------------|:------------------------------------------------------------------------------------------------------------------------|
| Actor         | Customer                                                                                                                |
| Description   | Company operator will choose the route.                                                                                 |
| Rationale     | This will allow company operator to receive confirmation in seconds, no need to wait until courier brings signed paper. |
| Fit Criterion | When customer receives parcel, he should click “Confirm Receipt” button. When system will notify company operator.      |
| Dependencies  | Independent                                                                                                             |

#### 38.   Company operator shall able to generate “Parcel Delivered” message.

| Requirement   | #38                                                                                                                                                                        |
|:--------------|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Company operator                                                                                                                                                           |
| Description   | Company operator will generate “Parcel Delivered” message.                                                                                                                 |
| Rationale     | This will allow a Company operator to monitor shipment phase and keep information up to date.                                                                              |
| Fit Criterion | Company Operator will be notified when parcel is received by customer, after that he/she should generate “Parcel Delivered” message by clicking “Parcel Delivered” button. |
| Dependencies  | Independent                                                                                                                                                                |

#### 39.   Control Supervisor shall be able to see customers feedback.

| Requirement   | #39                                                                                                                                                 |
|:--------------|:----------------------------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Control Supervisor                                                                                                                                  |
| Description   | Control Supervisor will request feedback from customer.                                                                                             |
| Rationale     | This will allow a Control Supervisor to assess customer satisfaction.                                                                               |
| Fit Criterion | Control supervisor chooses some order and there is a field with customers assessment or if it’s not there send customer an offer to leave feedback. |
| Dependencies  | Independent                                                                                                                                         |


#### 40.   Customer shall be able to leave feedback.

| Requirement   | #40                                                                                                                    |
|:--------------|:-----------------------------------------------------------------------------------------------------------------------|
| Actor         | Customer                                                                                                               |
| Description   | Customer will leave feedback.                                                                                          |
| Rationale     | This will enable Control Supervisor to assess customer satisfaction.                                                   |
| Fit Criterion | Customer have a special window to feedback, which he can fill any time and send it pressing the button”send feedback”. |
| Dependencies  | Independent                                                                                                            |

#### 41.   Control Supervisor shall be able to observe general trend of orders.

| Requirement   | #41                                                                                                                                       |
|:--------------|:------------------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Control Supervisor                                                                                                                        |
| Description   | Control Supervisor will observe general trend of orders.                                                                                  |
| Rationale     | This will enable Control Supervisor to predict new orders.                                                                                |
| Fit Criterion | Control supervisor will press a button “observe general trend” then system will show the statistics of orders through graphs or diagrams. |
| Dependencies  | Independent                                                                                                                               |


#### 42.   Control Supervisor shall be able to report of the day activity.

| Requirement   | #42                                                                                                                                 |
|:--------------|:------------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Control Supervisor                                                                                                                  |
| Description   | Control Supervisor will report of the day activity including status of the quality indicators, observation general trend and so on. |
| Rationale     | This will enable company to have all information in archive.                                                                        |
| Fit Criterion | Control Supervisor will have special form to fill with day activity report.                                                         |
| Dependencies  | Independent                                                                                                                         |

#### 43.    Control Supervisor shall be able to request statistical placement to the shipment.

| Requirement   | #43                                                                                                                                                           |
|:--------------|:--------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Control Supervisor                                                                                                                                            |
| Description   | Control Supervisor will request statistical placement to the shipment.                                                                                        |
| Rationale     | This will enable Control Supervisor to assess shipment.                                                                                                       |
| Fit Criterion | Control supervisor will choose some order and press button ”Statistical placement” and then the graph with the shipment compared to the others will be shown. |
| Dependencies  | 41                                                                                                                                                            |

#### 44.    Customer shall be able to get support in real time.

| Requirement   | #44                                                                                                                                                                |
|:--------------|:-------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Actor         | Customer                                                                                                                                                           |
| Description   | Customer can get support in real time.                                                                                                                             |
| Rationale     | This will allow Customer to get support instantly (in real time) without a long wait.                                                                              |
| Fit Criterion | Customer will open support form by clicking “Get support” and ask support (ask questions) by clicking “Send” button, system will send message to Company Operator. |
| Dependencies  | Independent                                                                                                                                                        |


#### 45.   Company Operator shall be able to support customers in real time.

| Requirement   | #45                                                                                                                  |
|:--------------|:---------------------------------------------------------------------------------------------------------------------|
| Actor         | Company Operator                                                                                                     |
| Description   | Company Operator will support customers in real time.                                                                |
| Rationale     | This will allow a Company operator to give support instantly (in real time).                                         |
| Fit Criterion | Company Operator will get message from Customer and send answer for appropriate Customer by clicking “Reply” button. |
| Dependencies  | 44                                                                                                                   |

#### 46. Customer will have possibility to receive updates if delivery is delayed 

| Requirement   | #46                                                                           |
|:--------------|:------------------------------------------------------------------------------|
| Actor         | Customer                                                                      |
| Description   | Customer will have ability to receive notifications if delivery was delayed . |
| Rationale     | To avoid dissatisfied customers system should notify in case of emergency     |
| Fit Criterion | User will receive an email or sms with new delivery time.                     |
| Dependencies  | Parcel                                                                        |


## 5. Other Non-Functional Requirements


#### NFR-01

| Type        | Security                                                                                                 |
|:------------|:---------------------------------------------------------------------------------------------------------|
| Description | No one will have an access to any user’s account information without a permission except the user itself |

#### NFR-02

| Type        | Security                                                                                  |
|:------------|:------------------------------------------------------------------------------------------|
| Description | Only users with correct login-password or track number will be given access to the system |

#### NFR-03

| Type        | Performance                                                                                   |
|:------------|:----------------------------------------------------------------------------------------------|
| Description | Users should receive tracking information about parcels in less than 30 seconds after request |

#### NFR-04

| Type        | Usability                                            |
|:------------|:-----------------------------------------------------|
| Description | All users should be satisfied with use of the system |

#### NFR-05

| Type        | Portability                                                           |
|:------------|:----------------------------------------------------------------------|
| Description | Drivers should be able to use the system on different Android devices |

#### NFR-06

| Type        | Safety                                           |
|:------------|:-------------------------------------------------|
| Description | Software should show only valid ways for drivers |

#### NFR-07

| Type        | Performance                                           |
|:------------|:------------------------------------------------------|
| Description | Software should generate routes in less than a minute |

#### NFR-08 

| Type        | Safety                                                            |
|:------------|:------------------------------------------------------------------|
| Description | Software should alert driver in case emergency weather conditions |

#### NFR-09	

| Type        | Safety                                                            |
|:------------|:------------------------------------------------------------------|
| Description | Every change on state of the parcel should be saved in parcel log |

#### NFR-10

| Type        | Usability                                                                              |
|:------------|:---------------------------------------------------------------------------------------|
| Description | Drivers app should work in offline to allow driver to see route and cached information |

#### NFR-11

| Type        | Usability                                                                                                    |
|:------------|:-------------------------------------------------------------------------------------------------------------|
| Description | The product shall be self‐explanatory and intuitive such that a customer will get all information by himself |

#### NFR-12 

| Type        | Reusability                                                  |
|:------------|:-------------------------------------------------------------|
| Description | The wather forecast should be collected from public services |

#### NFR-13 

| Type        | Availability                                                                                                                          |
|:------------|:--------------------------------------------------------------------------------------------------------------------------------------|
| Description | Unless the system is non‐operational, the system shall present a user with notification informing them that the system is unavailable |

#### NFR-14  

| Type        | Survivability                                                                                                 |
|:------------|:--------------------------------------------------------------------------------------------------------------|
| Description | If a transactions fails before it was saved, the system shall be able to recover all changes and notify user. |

#### NFR-15

| Type        | Availability                                                                                                       |
|:------------|:-------------------------------------------------------------------------------------------------------------------|
| Description | The system shall prevent access to failed functions while providing access to all currently operational functions. |

#### NFR-16  

| Type        | Maintainability                                                                      |
|:------------|:-------------------------------------------------------------------------------------|
| Description | The system shall not be shut down for maintenance more than once in a 24‐hour period |

#### NFR-17  

| Type        | Maintainability                                                                      |
|:------------|:-------------------------------------------------------------------------------------|
| Description | The software users should be notified in case of a bigger maintenance to the system. |

#### NFR-18

| Type        | Portability                                                                      |
|:------------|:---------------------------------------------------------------------------------|
| Description | The time zone shall be obvious to the user whenever a time element is displayed. |

#### NFR-19

| Type        | Usability                                                                |
|:------------|:-------------------------------------------------------------------------|
| Description | The parcel state should be shown in the timezone of the requested person |

#### NFR-20

| Type        | Usability                                                  |
|:------------|:-----------------------------------------------------------|
| Description | System registration process should be less than 10 seconds |

#### NFR-21

| Type        | Usability                                              |
|:------------|:-------------------------------------------------------|
| Description | System should allow e-mail or phone based registration |

#### NFR-22

| Type        | Availability                                                             |
|:------------|:-------------------------------------------------------------------------|
| Description | Users should have an access to the system and all resources all the time |
