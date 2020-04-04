
##RADIUS WHITEPAPER

Aim: The idea is to allow an opt-in crowdsourced intelligent application which  has the benefit of targeting the spreading of corona disease with minimal privacy invasion. 

The ultimate aim of Radius as it relates to Covid-19 is to encourage crowdsourced data about location and health status, to develop polygons around zones or suburbs or proximity to a person ('s phone as measured by bluetooth) and apply different rules (eg. Message: you are about enter a red zone. If you do, you will be required to quarantine for 14 days)

For lack of time, I am sending you some raw messages from our whatsapp channel which will give you an idea of what we are building.
Radius is an existing industrial safety application. We want to repurpose it for Covid-19. Polygons with rules are stored in a blockchain with smart contracts. The app alerts the device owner when they cross a boundary, such as a district in lockdown. The central 'database' of polygons and rules can be kept current. No private information is shared. There's already a provisional patent for the industrial safety use case. Covid-19 use case is free for everyone. Dev work required. Currently Android. Needs to be x-platform, so web assembly or similar tech. Currently Industrial Blockchain, which doesn't have smart contracts. Needs to be Ethereum or similar tech.

I'm going to prototype this very basically, using tech we have. Radius is currently a point source location systems distance from a point hence radius. i'm going to upgrade it to read a database of points from our cloud server as an interim b4 coding blockchain
so it alerts if the user goes within n km of a point where n is a rule in the cloud
Radius - Blockchain Integration Spec

We have a traditional cloud-based system that reads geographic rules from a central database and then implements those rules on devices.
The purpose of the system is to warn people when they leave or enter restricted zones in a coronavirus lockdown.

For example, if the device moves closer than 5k to a place, then sound an alarm.

Or if the device crosses a polygon edge defined in a geofencing service, send an SMS message.

This approach has advantages and disadvantages. One advantage is ease of development.

One disadvantage is scalability. What happens if 1m people hit the server at once? That's possible if the system is widely used.

Another disadvantage is trust. Why should anyone trust us to keep proper records?

A blockchain has the potential to solve those problems.

For example, instead of a central database, devices could efficiently store shards of rules in a blockchain [not the whole blockchain]. Then the app is authentically decentralized.
How do we use blockchain to store rules? In a smart contract.
Who write those contracts? Good question. We'd need a simple system to write them: part of the same suite that responds to the rules on the device.
What blockchain? Mine [Industrial bc] is unsuited to this.
We're building an MVP to be ready by next week, based on the coronavirus use case.
We'd like MVP2 to be blockchain enabled, so we can compare.

There may be a hybrid solution.