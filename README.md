# RoutesAndTimetables
RoutesAndTimetables

This solution was built using Xamarin(1.5) forms and has 3 projects.
- RoutesAndTimetables.Droid 
	-> Handles android specific rendering(Auto generated by Xamarin)
- RoutesAndTimetables.Business
	-> Handles Business Logic, contains the ViewModels, the Data Objects and the REST service integration(Built using RestSharp)
 -RoutesAndTimetables.Ui
    -> Handles the View Part of the project, also implements the Navigation Service defined in the business layer.
	
Packages Used:
	Xamarin
	Fody
	PropertyChanged.Fody
	RestSharp(manually added, included in repository)
	
To run it, you just need to open the solution in Visual/Xamarin Studio and compile