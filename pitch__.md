### Why do we need a ditributed architecture?

We believe people should own their personal information, controlling when and with whom they choose to share their data, especialy their real-time location.

In order to achive this and to have a greater levels of security than other technologies which use spatial/location data.


Future Potential:


* Reduced dependancy and better acuracy than what is provided by current technologies like GPS etc.

	+ GPS runs on an unencrypted protocol; withour any proof of authntication/origin thus there exists problems/loopholes in the technology like Spoofin of GPS location which is rather easily doable and acts as a threat to many services and applications which rely on GPS for functioning.
	

	+ Poor indoor localizaation and Inaccuracy: Problems can occur when obstacles, such as walls, buildings, skyscrapers and trees obstruct a signal. Extreme atmospheric conditions, such as geomagnetic storms, can also cause problems. In addition, the mapping technology which is used in conjunction with the GPS may not be up to date and cause navigational errors.
  
  +  Lack of local knowledge: Local knowledge counts for a lot when traveling. Relying solely on GPS technology means that you can miss out on information that might be local to your surroundings.
  
* Verifiable privacy standards; Differential privacy is a system for publicly sharing information about a dataset by describing the patterns of groups within the dataset while withholding information about individuals in the dataset.

* Accountablity: Data security shall be verifiable and any and every access to YOUR data can be verified.The data transactions that take place are transparent. The individuals who are provided authority can view the records.

* Energy intensive components are not suitable for devices with long maintenance cycles

* Resilient and scalable computer networks: Single Point of Failure(SPOC) failure of any of the componets which are required for positioning causes the GPS system to become non-functional.The decentralized nature of P2P networks increases robustness because it removes the single point of failure that can be inherent in a client-server based system


* The transactions are recorded in chronological order. Thus, all the blocks in the distributed architecture are time stamped; which can be beneficial for storage as location data changes over both over the space/co-ordinates and time domains.

* Use of a distributed architecture will allow us to leverage the application to make use of Low Power Wide Area Networks for localization/positioning systems without the use of GPS; LPWAN can offer the low power and longer battery life of bluetooth with the range of cellular. 


* With the smart contracts, the businesses can pre-set conditions on the blockchain. The automatic transactions are triggered only when the conditions are met, which is useful in our usecases of alerting the indivisual.

* Better scaling of the application as its not dependent on a centralized protocol used in GPS thus reach is not limited by the network reach of GPS techology.

* Lower cost to set-up and operate in the long-term ;easier to add a node to the system once set up.


*Possibilities*

1.  Decentralized computing for running the application by allocation resouces both hardware/software resources on all the nodes(mobile phones)/portable devices.Most of the devices are idle(w.r.t the full capacity of their compute capability) A decentralized system can use the potential of these systems to maximize efficiency and distribute the load of running the aplication dynamically over all nodes.


+ The availability and bandwidth available to share a file depends on how many peers are interested in it. The more interest there is, the more bandwidth is available  



2.  In some Peer-to-Peer networks, a server is employed to keep information on the individual peers and the files that they are sharing. This is used to locate files data on the P2P network, as well as to improve the network's efficiency.These P2P networks are sometimes referred to as hybrid P2P network. 



*Architecture*

A distributed network is designed around principle of equal peer nodes simultaneously functioning as both "clients" and "servers" to the other nodes on the network. This model of network arrangement differs from the client–server model where communication is usually to and from a central server. A typical example of a file transfer that uses the client-server model is the File Transfer Protocol (FTP) service in which the client and server programs are distinct: the clients initiate the transfer, and the servers satisfy these requests. 

Peer-to-peer networks generally implement a form of virtual overlay network on top of the physical network topology, where the nodes in the overlay form a subset of the nodes in the physical network. Data is still exchanged directly over the underlying TCP/IP network, but at the application layer peers are able to communicate with each other directly, via the logical overlay links (each of which corresponds to a path through the underlying physical network). Overlays are used for indexing and peer discovery, and make the P2P system independent from the physical network topology. Based on how the nodes are linked to each other within the overlay network, and how resources are indexed and located, we can classify networks as unstructured or structured (or as a hybrid between the two).

//Our system provides an entry point into a protocol of connected devices that provides high certainty on location data through  cryptographic proofs. Users are able to issue transactions, called “queries,” in order to retrieve a piece of location data on any blockchain platform possessing smart contract functionality

*(see more:Whitepaper/Tehinical Specifications)*


//add references, detailed architecture, anything skipped?, visualization and mind-map, small network simualtion(<100 nodes), check throughput via each protocols.

//Geospatial decentralized protocols, new node authentication and verification and participation in the network use of super nodes?
,Location encoding and data storacge architecture, PoL, Pee-to-Peer witnessing 



//Ideal conditions:speed, extensibility, flexibility and
moveable security while maintaining transparency and accountability.











