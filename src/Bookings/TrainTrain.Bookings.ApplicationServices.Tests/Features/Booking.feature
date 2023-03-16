Feature: Booking
Booking a travel for passengers

Scenario: Booking without passengers
	When I book without passenger
	Then I cannot book because there are no passenger

Scenario: Booking a travel without train
	Given a travel without train
	When I book a travel for these passengers
		| FirstName | LastName | BirthDate  |
		| John      | Doe      | 12/10/2020 |
		| Sarah     | Connor   | 12/10/2020 |
	Then I cannot book because there is no train

Scenario: Booking a full train
	Given a train with a capacity of 100 and 70 seats already booked
	When I book a travel for these passengers
		| FirstName | LastName | BirthDate  |
		| John      | Doe      | 12/10/2020 |
		| Sarah     | Connor   | 12/10/2020 |
	Then I cannot book because the train is full
	
Scenario: Booking train
	Given a train with a capacity of 100 and 40 seats already booked
	When I book a travel for these passengers
		| FirstName | LastName | BirthDate  |
		| John      | Doe      | 12/10/2020 |
		| Sarah     | Connor   | 12/10/2020 |
	Then my booking is ok