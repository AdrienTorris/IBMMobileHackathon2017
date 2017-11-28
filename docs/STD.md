# Sp�cifications Techniques D�taill�es

## Application Mobile

## APIs

Base Url: api/v1/

Return content type: JSON

Return base content : APIResponseViewModel

### Identity API

Base url :  http://ibmbooksid.opencodecamp.org/api/v1/

##### M�thodes expos�es

###### Enregistrement utilisateur

Url part: account/login
Method: POST
Param�tres: 
* 
Returns: 
* [Success] D�tails de l'utilisateur
* [Error] Code et message d'erreur

###### Connexion utilisateur

Signature : Register([FromBody]UserViewModel value)
Url part: account/register
Method: POST
Header :
* Content-Type : application/json
Param�tres: json en raw. Exemples :
* {"username":"test1@fr.ibm.com","password":"testtest"}
* {"username":"test1@fr.ibm.com","password":"testtest", "firstname":"Adrien","lastname":"Torris"}
Returns: 
* [Success] D�tails de l'utilisateur
* [Error] Code et message d'erreur

###### D�tails utilisateur (par identifiant)

Url part: getbyid
Method: GET
Param�tres: 
* id (O)
Returns: 
* [Success] D�tails de l'utilisateur
* [Error] Code et message d'erreur

###### D�tails utilisateur (par nom d'utilisateur)

Url part: getbyusername
Method: GET
Param�tres: 
* username (O)
Returns: 
* [Success] D�tails de l'utilisateur
* [Error] Code et message d'erreur

###### D�tails utilisateur (par email)

Url part: getbyemail
Method: GET
Param�tres: 
* mail (O)
Returns: 
* [Success] D�tails de l'utilisateur
* [Error] Code et message d'erreur

### Catalog API

Base url : http://ibmbookscatg.opencodecamp.org/api/v1/

#### Book Reference

Base url : bookreference/

###### Liste des r�f�rences

Url part: list
Method: GET
Param�tres: 
* pageSize (F)
* pageIndex (F)
* searchQuery (F) : filtre de recherche
Returns: 
* [Success] D�tails de l'utilisateur
* [Error] Code et message d'erreur

###### D�tails d'une r�f�rence avec la liste des items associ�s

Signature : GetWithItems([FromQuery]int id, [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 30)
Method: GET
Param�tres:
* id (O) : identifiant de la r�f�rence
* pageSize (F)
* pageIndex (F)
Returns: 
* [Success] D�tails de la r�f�rence + liste des items associ�s
* [Error] Code et message d'erreur

##### M�thodes expos�es

#### Book Items

Base url : bookitem/

##### M�thodes expos�es

###### Liste les items d'une r�f�rence

Url part: ListByReference
Method: GET
Param�tres: 
* id (O) -> identifiant de la r�f�rence pour laquelle lister les items
* pageSize
* pageIndex
Returns: 
* [Success] 
* [Error] Code et message d'erreur

###### Retourne une r�f�rence selon son ISBN

Signature : GetByISBN([FromQuery]string isbn)
Url part: /{valeur isbn}
Method: GET
Param�tres: 
* 
Returns: 
* [Success] 
* [Error] Code et message d'erreur

###### Ajout d'un ouvrage par r�f�rence

Signature : AddByReference([FromForm]int referenceId, [FromForm]int ownerId, [FromForm]string ownerRemarks)
Url part: AddByReference
Method: POST
Param�tres: 
* referenceId (O) -> identifiant de la r�f�rence pour laquelle lister les items
* ownerId (O) -> identifiant de l'utilisateur
* ownerRemarks (F) -> commentaire optionnel de l'utilisateur (ex: 'livre ab�m�' ou 'tr�s bonne lecture, je recommande')
Returns: 
* [Success] 
* [Error] Code et message d'erreur

###### Ajout d'un ouvrage, mode d�grad�

Signature : Add([FromForm]int ownerId, [FromForm]string ownerRemarks, [FromForm]string isbn, [FromForm]string lang, [FromForm]string title, [FromForm]string publisher, [FromForm]string author)
Url part: Add
Method: POST
Param�tres: 
* ownerId (O) -> identifiant de l'utilisateur
* ownerRemarks (F) -> commentaire optionnel de l'utilisateur (ex: 'livre ab�m�' ou 'tr�s bonne lecture, je recommande')
* isbn (O) -> num�ro ISBN de l'ouvrage
* lang (O) -> langue du livre, sur 2 caract�res ('fr' pour fran�ais, 'en' pour anglais, 'it' pour italien, etc)
* title (O) -> titre du livre
* publisher (O) -> nom de l'�diteur
* author (O) -> nom de/des auteur(s) (si plusieurs auteurs, les s�parer par des virgules, ou des points virgules). Ex de valeur : 'Auteur 1;Auteur 2'
Returns: 
* [Success] 
* [Error] Code et message d'erreur

###### Mise � jour du statut

Signature : Task<JsonResult> UpdateAvailability([FromForm]int id, [FromForm]bool availability)
Url part: UpdateAvailability
Method: POST
Param�tres: 
* id (O) -> identifiant de l'item
* availability (O) -> le libre est-il disponible ou pas ?
Returns: 
* [Success] 
* [Error] Code et message d'erreur

###### liste les items d'un utilisateur

Signature : ListByOwner([FromQuery]int id, [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 30)
Url part: ListByOwner
Method: GET
Param�tres: 
* id (O) : identifiant de l'utilisateur
* pageIndex (F)
* pageSize (O)
Returns: 
* [Success] 
* [Error] Code et message d'erreur

#### Service de messagerie

Base url : message/

##### M�thodes expos�es

###### Liste des messages re�us par un utilisateur

Signature : ListByReceiver([FromQuery]int id, [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 15)
Url part: ListByReceiver
Method: GET
Param�tres: 
* id (O) -> identifiant de l'utilisateur
* pageSize
* pageIndex
Returns: 
* [Success] 
* [Error] Code et message d'erreur

###### Liste des messages envoy�s par un utilisateur

Signature : ListBySender([FromQuery]int id, [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 15)
Url part: ListByReference
Method: GET
Param�tres: 
* id (O) -> identifiant de l'utilisateur
* pageSize
* pageIndex
Returns: 
* [Success] 
* [Error] Code et message d'erreur

###### Cr�ation d'un message (d�clenche l'envoi de mail)

Signature :  Send([FromBody]MessageViewModel value)
Url part: Send
Method: POST
Header :
* Content-Type : application/json
Param�tres: 
* 
Returns: 
* [Success] 
* [Error] Code et message d'erreur