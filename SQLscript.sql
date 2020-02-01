/*
2020Analisis: "1.0.0"
info:
  description: 
  "Gestiona el almacenamiento de la informacion relacionada
   a las vacaciones de los trabajadores de la municipalidad de paraiso"

  license: "Microsoft"
    name:  "Microsoft SQL server 2017 developer edition"
    url:   "https://www.microsoft.com/es-es/sql-server/sql-server-2017-pricing"

 /*CREACIÓN DE ESQUEMAS*/
USE 2020Analisis
GO
CREATE SCHEMA VACATIONS;
CREATE SCHEMA ERS;
GO

 /*CREACIÓN DE TABLAS*/
CREATE TABLE [VACATIONS].[Day] (
  [day]     datetime NOT NULL, 
  createdAt datetime NOT NULL, 
  updatedAt datetime NOT NULL, 
  createdBy int NOT NULL, 
  updatedBy int NOT NULL, 
  isHoliday int NULL, 
  PRIMARY KEY ([day]),
  CONSTRAINT U_day UNIQUE(day));

CREATE TABLE VACATIONS.Departament (
  departamentId   int IDENTITY NOT NULL, 
  name            varchar(10) NOT NULL, 
  createdBy       int NOT NULL, 
  updatedBy       int NOT NULL, 
  createdAt       datetime NOT NULL, 
  udaedAt         datetime NOT NULL, 
  PersonpersonaId int NOT NULL, 
  PRIMARY KEY (departamentId));

CREATE TABLE VACATIONS.HoliDays (
  holiDaysId   int IDENTITY NOT NULL, 
  isObligatory tinyint NOT NULL, 
  [date]       datetime NOT NULL, 
  isPaid       tinyint NOT NULL, 
  cratedAt     datetime NOT NULL, 
  updatedAt    datetime NOT NULL, 
  createdBy    int NOT NULL, 
  updatedBy    int NOT NULL, 
  DayDay       datetime NULL, 
  PRIMARY KEY (holiDaysId));
  
CREATE TABLE VACATIONS.Payroll (
  RolId       int IDENTITY NOT NULL, 
  salary      int NOT NULL, 
  bonusSalary int NOT NULL, 
  createdAt   datetime NOT NULL, 
  updatedAt   datetime NOT NULL, 
  createdBy   int NOT NULL, 
  updatedBy   int NOT NULL, 
  PRIMARY KEY (RolId));
  
CREATE TABLE VACATIONS.Permission (
  permisoId   int IDENTITY NOT NULL, 
  name        varchar(10) NOT NULL, 
  description varchar(10) NOT NULL, 
  RolRolId    int NOT NULL, 
  createdAt   datetime NOT NULL, 
  updatedAt   datetime NOT NULL, 
  createdBy   int NOT NULL, 
  updatedBy   int NOT NULL, 
  PRIMARY KEY (permisoId));

CREATE TABLE VACATIONS.Person (
  personaId      int IDENTITY NOT NULL, 
  [name]         varchar(20) NOT NULL, 
  lastName       varchar(40) NOT NULL, 
  identification int NOT NULL, 
  email          varchar(100) NOT NULL, 
  [password]     varchar(20) NOT NULL, 
  createdAt      datetime NOT NULL, 
  updatedAt      datetime NOT NULL, 
  createdBy      int NOT NULL, 
  updatedBy      int NOT NULL, 
  PayrollRolId   int NOT NULL, 
  PRIMARY KEY (personaId));

CREATE TABLE VACATIONS.Request (
  requestId          int IDENTITY NOT NULL, 
  [state]            varchar(10) NOT NULL, 
  description        varchar(200) NOT NULL, 
  daysRequestedCount int NOT NULL, 
  midDaysCount       int NOT NULL, 
  PersonpersonaId    int NOT NULL, 
  createdAt          datetime NOT NULL, 
  updatedAt          datetime NOT NULL, 
  createdBy          int NOT NULL, 
  updatedBy          int NOT NULL, 
  PRIMARY KEY (requestId),
  Constraint CH_State CHECK([state] IN ('acepted','rejected','sent')));

CREATE TABLE VACATIONS.Rol (
  rolId           int IDENTITY NOT NULL, 
  name            varchar(10) NOT NULL, 
  description     varchar(10) NOT NULL, 
  PersonpersonaId int NOT NULL, 
  createdAt       datetime NOT NULL, 
  updatedAt       datetime NOT NULL, 
  createdBy       int NOT NULL, 
  updatedBy       int NOT NULL, 
  PRIMARY KEY (rolId));

CREATE TABLE VACATIONS.VacationInfo (
  vacationId       int IDENTITY NOT NULL, 
  availableDays    int NOT NULL, 
  DaysPerYear      int NOT NULL, 
  createdAt        datetime NOT NULL, 
  updatedAt        datetime NOT NULL, 
  createdBy        int NOT NULL, 
  updatedBy        int NOT NULL, 
  RequestrequestId int NOT NULL, 
  PRIMARY KEY (vacationId));

CREATE TABLE VACATIONS.Person_Departament (
  PersonpersonaId          int NOT NULL, 
  DepartamentdepartamentId int NOT NULL, 
  PRIMARY KEY (PersonpersonaId, 
  DepartamentdepartamentId));

CREATE TABLE VACATIONS.Person_Rol (
  PersonpersonaId int NOT NULL, 
  RolRolId        int NOT NULL, 
  PRIMARY KEY (PersonpersonaId, 
  RolRolId));
  
CREATE TABLE VACATIONS.Rol_Permission (
  RolRolId            int NOT NULL, 
  PermissionpermisoId int NOT NULL, 
  PRIMARY KEY (RolRolId, 
  PermissionpermisoId));


 /*CREACIÓN DE RELACIONES*/
ALTER TABLE VACATIONS.Rol_Permission ADD 
CONSTRAINT FKRol_Permis414931 FOREIGN KEY (PermissionpermisoId) REFERENCES VACATIONS.Permission (permisoId);

ALTER TABLE VACATIONS.Rol_Permission ADD 
CONSTRAINT FKRol_Permis788078 FOREIGN KEY (RolRolId) REFERENCES VACATIONS.Rol (rolId);

ALTER TABLE VACATIONS.Person_Rol ADD 
CONSTRAINT FKPerson_Rol441355 FOREIGN KEY (RolRolId) REFERENCES VACATIONS.Rol (rolId);

ALTER TABLE VACATIONS.Person_Rol ADD 
CONSTRAINT FKPerson_Rol100945 FOREIGN KEY (PersonpersonaId) REFERENCES VACATIONS.Person (personaId);

ALTER TABLE VACATIONS.Person_Departament ADD 
CONSTRAINT FKPerson_Dep631438 FOREIGN KEY (DepartamentdepartamentId) REFERENCES VACATIONS.Departament (departamentId);

ALTER TABLE VACATIONS.Person_Departament ADD 
CONSTRAINT FKPerson_Dep672635 FOREIGN KEY (PersonpersonaId) REFERENCES VACATIONS.Person (personaId);

ALTER TABLE VACATIONS.Request ADD 
CONSTRAINT [manages] FOREIGN KEY (PersonpersonaId) REFERENCES VACATIONS.Person (personaId);

ALTER TABLE VACATIONS.Person ADD 
CONSTRAINT Belongs FOREIGN KEY (PayrollRolId) REFERENCES VACATIONS.Payroll (RolId);

ALTER TABLE VACATIONS.VacationInfo ADD 
CONSTRAINT Has FOREIGN KEY (RequestrequestId) REFERENCES VACATIONS.Request (requestId);

ALTER TABLE VACATIONS.[Day] ADD 
CONSTRAINT Has_ FOREIGN KEY (isHoliday) REFERENCES VACATIONS.Request (requestId);

ALTER TABLE VACATIONS.HoliDays ADD 
CONSTRAINT [Is] FOREIGN KEY (DayDay) REFERENCES VACATIONS.[Day] ([day]);


CREATE TABLE ERS.Person (
  personaId      int IDENTITY NOT NULL, 
  [name]         varchar(20) NOT NULL, 
  lastName       varchar(40) NOT NULL, 
  identification int NOT NULL, 
  email          varchar(100) NOT NULL, 
  [password]     varchar(20) NOT NULL, 
  createdAt      datetime NOT NULL, 
  updatedAt      datetime NOT NULL, 
  createdBy      int NOT NULL, 
  updatedBy      int NOT NULL, 
  PayrollRolId   int NOT NULL, 
  PRIMARY KEY (personaId));

/*CREACIÓN DE PRPCEDIMIENTOS ALMACENADOS*/

/*PENDIENTE*/