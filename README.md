# WinForms architecture patterns

A simple WinForms app built using different architectural patterns:

* **Plain**: everything is in the views' code behind files.
    * Pros: easiest approach.
    * Cons: no separation of concerns. Difficult to maintain as the apps grows. Untestable.

* **Layered**: data access code is in a separate layer.
    * Pros: separates the main concerns. Not too complicated. Some parts of the app are testable.
    * Cons: the view code is still big and hard to test.

* **MVP with Passive View**: follows the [Model-View-Presenter](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93presenter) pattern, [Passive View](http://www.martinfowler.com/eaaDev/PassiveScreen.html)-style.
    * Pros: concerns are clearly separated. Most of the app is testable, including UI logic code (in presenters).
    * Cons: complicates the architecture. Presenter<->View data sync is tedious. A bit overkill for some projects.

Some interesting resources on the topic:

* http://stackoverflow.com/questions/2056/what-are-mvp-and-mvc-and-what-is-the-difference
* http://aspiringcraftsman.com/2007/08/25/interactive-application-architecture/
* http://codebetter.com/jeremymiller/2007/07/26/the-build-your-own-cab-series-table-of-contents/
* https://github.com/mrts/winforms-mvp
* http://aviadezra.blogspot.fr/2008/10/model-view-presenter-design-pattern.html




