# UglyToad.MakeMe #

A test data generator for creating meaningful randomised data. Intended to be used for filling databases with data, providing data for automation tests and for integration tests.

Currently generates the following:

+ Dates - with or without time component.
+ Names - names which are are sometimes sort-of pronounceable, not just random combinations of letters.
+ Postal Codes - valid format UK postcodes, generic 5 digit postcodes for other countries and 6 digit postcodes for India.
+ Numbers - Supports generation of pseudo-random Normal Distribution integers.

Plans to support the following:

+ Emails
+ Addresses
+ Sentences and bodies of text.

Also it's planned that this will support:

+ Creation of test data scripts from a console application which runs against a database.
+ Instantiation of classes with test data using reflection.

## Using it ##

There is one static method which provides the method to configure and generate data:

    TestDataFactory.Make(A...);

The Make method takes a data specification of the following form:

    A.PostalCode()

Or another example:

    A.Name()

These specifications then provide further configuration methods:

    A.PostalCode().FromUnitedKingdom().IncludeInvalid(10)

The Make method optionally takes a seed. The seed is used by the random number generator. If you provide a seed the generated data will be consistent on all future runs:

    TestDataFactory.Make(A.PostalCode(), 25)

Finally to actually generate the data you can generate either a single record or an enumerable. For an enumerable with 250 records:

    TestDataFactory.Make(A.PostalCode()).GenerateSeries(250);

Or for a single record:

    TestDataFactory.Make(A.PostalCode()).Generate();