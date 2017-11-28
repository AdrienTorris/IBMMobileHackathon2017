# Spécifications Techniques Détaillées

## Application Mobile

## APIs

Base Url: api/v1/

Return content type: JSON

Return base content : APIResponseViewModel

### Identity API

Base url :  http://ibmbooksid.opencodecamp.org/api/v1/

##### Méthodes exposées

###### Enregistrement utilisateur

Url part: account/login
Method: POST
Paramètres: 
* 
Returns: 
* [Success] Détails de l'utilisateur
* [Error] Code et message d'erreur

###### Connexion utilisateur

Signature : Register([FromBody]UserViewModel value)
Url part: account/register
Method: POST
Header :
* Content-Type : application/json
Paramètres: json en raw. Exemples :
* {"username":"test1@fr.ibm.com","password":"testtest"}
* {"username":"test1@fr.ibm.com","password":"testtest", "firstname":"Adrien","lastname":"Torris"}
Returns: 
* [Success] Détails de l'utilisateur
* [Error] Code et message d'erreur

###### Détails utilisateur (par identifiant)

Url part: getbyid
Method: GET
Paramètres: 
* id (O)
Returns: 
* [Success] Détails de l'utilisateur
* [Error] Code et message d'erreur

###### Détails utilisateur (par nom d'utilisateur)

Url part: getbyusername
Method: GET
Paramètres: 
* username (O)
Returns: 
* [Success] Détails de l'utilisateur
* [Error] Code et message d'erreur

###### Détails utilisateur (par email)

Url part: getbyemail
Method: GET
Paramètres: 
* mail (O)
Returns: 
* [Success] Détails de l'utilisateur
* [Error] Code et message d'erreur

### Catalog API

Base url : http://ibmbookscatg.opencodecamp.org/api/v1/

#### Book Reference

Base url : bookreference/

###### Liste des références

Url part: list
Method: GET
Paramètres: 
* pageSize (F)
* pageIndex (F)
* searchQuery (F) : filtre de recherche
Returns: 
* [Success] Détails de l'utilisateur
* [Error] Code et message d'erreur

###### Détails d'une référence avec la liste des items associés

Signature : GetWithItems([FromQuery]int id, [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 30)
Method: GET
Paramètres:
* id (O) : identifiant de la référence
* pageSize (F)
* pageIndex (F)
Returns: 
* [Success] Détails de la référence + liste des items associés
* [Error] Code et message d'erreur

##### Méthodes exposées

#### Book Items

Base url : bookitem/

##### Méthodes exposées

###### Liste les items d'une référence

Url part: ListByReference
Method: GET
Paramètres: 
* id (O) -> identifiant de la référence pour laquelle lister les items
* pageSize
* pageIndex
Returns: 
* [Success] 
* [Error] Code et message d'erreur

###### Retourne une référence selon son ISBN

Signature : GetByISBN([FromQuery]string isbn)
Url part: /{valeur isbn}
Method: GET
Paramètres: 
* 
Returns: 
* [Success] 
* [Error] Code et message d'erreur

###### Ajout d'un ouvrage par référence

Signature : AddByReference([FromForm]int referenceId, [FromForm]int ownerId, [FromForm]string ownerRemarks)
Url part: AddByReference
Method: POST
Paramètres: 
* referenceId (O) -> identifiant de la référence pour laquelle lister les items
* ownerId (O) -> identifiant de l'utilisateur
* ownerRemarks (F) -> commentaire optionnel de l'utilisateur (ex: 'livre abîmé' ou 'très bonne lecture, je recommande')
Returns: 
* [Success] 
* [Error] Code et message d'erreur

###### Ajout d'un ouvrage, mode dégradé

Signature : Add([FromForm]int ownerId, [FromForm]string ownerRemarks, [FromForm]string isbn, [FromForm]string lang, [FromForm]string title, [FromForm]string publisher, [FromForm]string author)
Url part: Add
Method: POST
Paramètres: 
* ownerId (O) -> identifiant de l'utilisateur
* ownerRemarks (F) -> commentaire optionnel de l'utilisateur (ex: 'livre abîmé' ou 'très bonne lecture, je recommande')
* isbn (O) -> numéro ISBN de l'ouvrage
* lang (O) -> langue du livre, sur 2 caractères ('fr' pour français, 'en' pour anglais, 'it' pour italien, etc)
* title (O) -> titre du livre
* publisher (O) -> nom de l'éditeur
* author (O) -> nom de/des auteur(s) (si plusieurs auteurs, les séparer par des virgules, ou des points virgules). Ex de valeur : 'Auteur 1;Auteur 2'
Returns: 
* [Success] 
* [Error] Code et message d'erreur

###### Mise à jour du statut

Signature : Task<JsonResult> UpdateAvailability([FromForm]int id, [FromForm]bool availability)
Url part: UpdateAvailability
Method: POST
Paramètres: 
* id (O) -> identifiant de l'item
* availability (O) -> le libre est-il disponible ou pas ?
Returns: 
* [Success] 
* [Error] Code et message d'erreur

###### liste les items d'un utilisateur

Signature : ListByOwner([FromQuery]int id, [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 30)
Url part: ListByOwner
Method: GET
Paramètres: 
* id (O) : identifiant de l'utilisateur
* pageIndex (F)
* pageSize (O)
Returns: 
* [Success] 
* [Error] Code et message d'erreur

#### Service de messagerie

Base url : message/

##### Méthodes exposées

###### Liste des messages reçus par un utilisateur

Signature : ListByReceiver([FromQuery]int id, [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 15)
Url part: ListByReceiver
Method: GET
Paramètres: 
* id (O) -> identifiant de l'utilisateur
* pageSize
* pageIndex
Returns: 
* [Success] 
* [Error] Code et message d'erreur

###### Liste des messages envoyés par un utilisateur

Signature : ListBySender([FromQuery]int id, [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 15)
Url part: ListByReference
Method: GET
Paramètres: 
* id (O) -> identifiant de l'utilisateur
* pageSize
* pageIndex
Returns: 
* [Success] 
* [Error] Code et message d'erreur

###### Création d'un message (déclenche l'envoi de mail)

Signature :  Send([FromBody]MessageViewModel value)
Url part: Send
Method: POST
Header :
* Content-Type : application/json
Paramètres: 
* 
Returns: 
* [Success] 
* [Error] Code et message d'erreur