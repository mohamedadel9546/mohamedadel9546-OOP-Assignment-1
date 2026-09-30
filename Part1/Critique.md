#### Overview
This document provides a technical critique of the C++ procedural implementation of the Order System (`order_system.cpp`).
The current implementation relies strictly on global state,
parallel primitive arrays,Limited Space, and unencapsulated free functions. 

## 1. Global State and Parallel Arrays
Any one in the app can modify in Global State Without any control and rules the app depend on the limited parallel array and index,
this is big problem because the app not scalable and any one modify the index in one array and not modify in the parallel the data and arrays 
are loss and curraption.

## Not Include Encapsulation
Withot Encapsulation in the app leads to randomness and not control in the app any one in it read,write,modify on the data.


## Absence and violation the Single Responsiblity Prinsple (SRP)
the free method do more than work in the same time (validation,bussines logic,print) leads to zero reusbilty ,
hard to maintain any thing in the method

## The OOP solve all this problems 