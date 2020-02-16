
2020Analisis: "1.0.0"
info:
  description: 
  "Gestiona el almacenamiento de la informacion relacionada
   a las vacaciones de los trabajadores de la municipalidad de paraiso"

  license: "Microsoft"
    name:  "Microsoft SQL server 2017 developer edition"
    url:   "https://www.microsoft.com/es-es/sql-server/sql-server-2017-pricing"

 /*CREACIÓN DE ESQUEMAS*/

 Create database 2020Analisis

USE 2020Analisis
GO
CREATE SCHEMA VACATIONS;
CREATE SCHEMA ERS;
GO

 CREATE TABLE VACATIONS.Day (
  dayId            int IDENTITY NOT NULL, 
  day              datetime NOT NULL UNIQUE, 
  turn             int NOT NULL, 
  createdAt        datetime NOT NULL, 
  updatedAt        datetime NOT NULL, 
  createdBy        int NOT NULL, 
  updatedBy        int NOT NULL, 
  RequestrequestId int NOT NULL, 
  PRIMARY KEY (dayId));

CREATE TABLE VACATIONS.Departament (
  departamentId   int IDENTITY NOT NULL, 
  name            varchar(30) NOT NULL, 
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
  name        varchar(30) NOT NULL, 
  description varchar(100) NOT NULL, 
  RolRolId    int NOT NULL, 
  createdAt   datetime NOT NULL, 
  updatedAt   datetime NOT NULL, 
  createdBy   int NOT NULL, 
  updatedBy   int NOT NULL, 
  PRIMARY KEY (permisoId));

CREATE TABLE VACATIONS.Person1 (
  personaId      int IDENTITY NOT NULL, 
  name           varchar(20) NOT NULL, 
  lastName       varchar(40) NOT NULL, 
  identification int NOT NULL, 
  email          varchar(100) NOT NULL, 
  password       varchar(300) NOT NULL, 
  createdAt      datetime NOT NULL, 
  updatedAt      datetime NOT NULL, 
  createdBy      int NOT NULL, 
  updatedBy      int NOT NULL, 
  PayrollRolId   int NOT NULL, 
  RolrolId       int NOT NULL, 
  PRIMARY KEY (personaId));

CREATE TABLE VACATIONS.Person_Departament (
  PersonpersonaId          int NOT NULL, 
  DepartamentdepartamentId int NOT NULL, 
  PRIMARY KEY (PersonpersonaId, 
  DepartamentdepartamentId));

CREATE TABLE VACATIONS.Request (
  requestId          int IDENTITY NOT NULL, 
  state              varchar(10) NOT NULL, 
  description        varchar(200) NOT NULL, 
  daysRequestedCount int NOT NULL, 
  midDaysCount       int NOT NULL, 
  createdAt          datetime NOT NULL, 
  updatedAt          datetime NOT NULL, 
  createdBy          int NOT NULL, 
  updatedBy          int NOT NULL, 
  PersonpersonaId    int NOT NULL, 
  PRIMARY KEY (requestId));

CREATE TABLE VACATIONS.Rol (
  rolId           int IDENTITY NOT NULL, 
  name            varchar(30) NOT NULL, 
  description     varchar(60) NOT NULL, 
  PersonpersonaId int NOT NULL, 
  createdAt       datetime NOT NULL, 
  updatedAt       datetime NOT NULL, 
  createdBy       int NOT NULL, 
  updatedBy       int NOT NULL, 
  PRIMARY KEY (rolId));

CREATE TABLE VACATIONS.Rol_Permission (
  RolRolId            int NOT NULL, 
  PermissionpermisoId int NOT NULL, 
  PRIMARY KEY (RolRolId, 
  PermissionpermisoId));

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


ALTER TABLE VACATIONS.Rol_Permission ADD 
CONSTRAINT FKRol_Permis414931 FOREIGN KEY (PermissionpermisoId) REFERENCES VACATIONS.Permission (permisoId);

ALTER TABLE VACATIONS.Rol_Permission ADD 
CONSTRAINT FKRol_Permis788078 FOREIGN KEY (RolRolId) REFERENCES VACATIONS.Rol (rolId);

ALTER TABLE VACATIONS.Person_Departament ADD 
CONSTRAINT FKPerson_Dep631438 FOREIGN KEY (DepartamentdepartamentId) REFERENCES VACATIONS.Departament (departamentId);

ALTER TABLE VACATIONS.Person_Departament ADD 
CONSTRAINT FKPerson_Dep234518 FOREIGN KEY (PersonpersonaId) REFERENCES VACATIONS.Person1 (personaId);

ALTER TABLE VACATIONS.Request ADD 
CONSTRAINT [manages] FOREIGN KEY (PersonpersonaId) REFERENCES VACATIONS.Person1 (personaId);

ALTER TABLE VACATIONS.Person1 ADD 
CONSTRAINT Belongs FOREIGN KEY (PayrollRolId) REFERENCES VACATIONS.Payroll (RolId);

ALTER TABLE VACATIONS.Day ADD 
CONSTRAINT HasDays FOREIGN KEY (RequestrequestId) REFERENCES VACATIONS.Request (requestId);

ALTER TABLE VACATIONS.Person1 ADD 
CONSTRAINT HasPersons FOREIGN KEY (RolrolId) REFERENCES VACATIONS.Rol (rolId);

ALTER TABLE VACATIONS.VacationInfo ADD 
CONSTRAINT HasRequest FOREIGN KEY (RequestrequestId) REFERENCES VACATIONS.Request (requestId);


Alter table VACATIONS.Person1 ADD CONSTRAINT identification_ck UNIQUE (identification);
Alter table VACATIONS.request ADD CONSTRAINT CH_State CHECK([state] IN ('acepted','rejected','sent'));

/*inserts*/
INSERT into VACATIONS.Rol (name, description, createdAt, updatedAt, createdBy, updatedBy) 
  values ('Employee', 'Vacations', GETDATE(), GETDATE(), 305150456, 305150456), 
		 ('Administator', 'Vacations', GETDATE(), GETDATE(), 308900456, 308900456),
		 ('Manager', 'Vacations', GETDATE(), GETDATE(), 208950456, 208950456);


INSERT into VACATIONS.Payroll(salary, bonusSalary, createdAt, updatedAt, createdBy, updatedBy) 
  values (450000, 0,  GETDATE(), GETDATE(), 308900456, 308900456),
		 (650000, 0,  GETDATE(), GETDATE(), 308900456, 308900456),
		 (800000, 0,  GETDATE(), GETDATE(), 308900456, 308900456),
		 (550000, 0,  GETDATE(), GETDATE(), 308900456, 308900456) ;


INSERT into VACATIONS.Person1 (name, lastName, identification, email, password, createdAt, updatedAt, createdBy, updatedBy, PayrollRolId, RolrolId) 
  values ('Sonia Lucia','Mata Coto', 305150456,  'sonia2016M@gmail.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', GETDATE(), GETDATE(), 305150456, 305150456, 1,7),
		 ('Xiomara','Sánchez Meza', 308900406,  'xiomara2016S@gmail.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', GETDATE(), GETDATE(), 305150456, 305150456, 2,8),
		 ('William','Solano Durán', 308950476,  'william2016S@gmail.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', GETDATE(), GETDATE(), 305150456, 305150456, 3,9),
		 ('Damaris','Solano Castillo', 301890456,  'damaria2016S@gmail.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', GETDATE(), GETDATE(), 305150456, 305150456, 1,7),
		 ('Ivannia Marcela',' Solano Vega', 306750056, 'xiomara2016I@gmail.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', GETDATE(), GETDATE(), 305150456, 305150456, 2,8),	
		 ('Nelson Andrés','Moya Moya', 301320456,  'nelson2016M@gmail.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', GETDATE(), GETDATE(), 305150456, 305150456, 3,9);

INSERT into VACATIONS.Departament (name, PersonpersonaId, updatedBy, createdAt, udaedAt,  createdBy) 
  values ('RRHH', 309940167, 309940167, GETDATE(), GETDATE(), 309940167),
		 ('Tecnolgías de Información', 309600168, 309940167, GETDATE(), GETDATE(), 309940167),
		 ('Patentes', 307640167, 309940167, GETDATE(), GETDATE(), 309940167),
		 ('Cobros', 308640167, 309940167, GETDATE(), GETDATE(), 309940167),
		 ('Proveeduría', 304640167, 309940167, GETDATE(), GETDATE(), 309940167),
		 ('Catastro', 309040167, 309940167, GETDATE(), GETDATE(), 309940167),
		 ('Tesorería', 304650167, 309940167, GETDATE(), GETDATE(), 309940167),
		 ('Auditoria Interna', 309640197, 309940167, GETDATE(), GETDATE(), 309940167),
		 ('Administrativo Financiero', 309640137, 309940167, GETDATE(), GETDATE(), 309940167),
		 ('Presupuesto', 304640147, 309940167, GETDATE(), GETDATE(), 309940167),
		 ('Ingeniería', 302640159, 309940167, GETDATE(), GETDATE(), 309940167),
		 ('Servicios Generales', 309510167, 309940167, GETDATE(), GETDATE(), 309940167);

		 select * from VACATIONS.Person1
		 
INSERT into VACATIONS.Person_Departament(PersonpersonaId, DepartamentdepartamentId)
		 values (8,1),
				(9,2),
				(10,3),
				(11,4),
				(12,5),
				(13,6),
				(8,7),
				(9,8),
				(10,9),
				(11,6),
				(12,4),
				(12,3);

SELECT * FROM VACATIONS.Person1;
