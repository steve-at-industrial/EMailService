# EMailService
Service to receive Email message body and respond with one of two response types

This project was created as part of a technical interview so while most of the scaffolding
you would expect to see in a commercial grade product exists, not all will be completely filled in
e.g. while there is a unit test project it has a lower than normal number of unit tests as the goal is to 
demonstrate capability to the reviewer and not necessarily provide 100% test code coverage.

Ditto for a logging and alerting framework. My defacto choice for this is log4Net and while I would never produce
a commercial product WITHOUT this (or a similar) framework, I didn't judge it necessary for the interview.

For privacy reasons I won't go into detail of the interviewing organisation or the specifics of the assignment but
the short version of the brief is to produce a RESTful API that will accept one of two (embedded) message types within
a text stream, decode them, validate them and (if valid) return a structured (i.e. JSON/XML) response to the caller.


