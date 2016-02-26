Functionaliteit: Zoeken van pagina teksten op website Kleinenijn.nl
	Om teskten op de kleinenijn site te zoeken
	Als een sitebeheerder
	Wil ik automatisch teksten kunnen controleren
	
@KleinenijnIntakeTest
Abstract Scenario: Ga naar de Kleinenijn site en controleer pagina's
	Gegeven Ik ga naar de volgende pagina <Website>
    En Ik zie dat de pagina geladen is
	Als Ik klik op de knop <MenuKnop>
	#Als Ik zie dat de pagina geladen is en klik op de knop <MenuKnop>
	Dan Wordt de tekst <PaginaTekst> op een pagina van de site gevonden
Voorbeelden: 
| Website       | MenuKnop   | PaginaTekst                  |
| Kleinenijn.nl | Welkom     | Huiselijk en vertrouwd       |
| Kleinenijn.nl | Foto's     | Foto's                       |
| Kleinenijn.nl | Kosten     | Tarieven en wat u moet weten |
| Kleinenijn.nl | Contact    | Contact                      |