/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [personaId]
      ,[name]
      ,[lastName]
      ,[identification]
      ,[email]
      ,[password]
      ,[createdAt]
      ,[updatedAt]
      ,[createdBy]
      ,[updatedBy]
      ,[PayrollRolId]
  FROM [2020Analisis].[VACATIONS].[Person]

  use [2020Analisis]

  Delete VACATIONS.Rol where rolId = 3
  Delete VACATIONS.Payroll where rolId = 1
   Delete VACATIONS.Person where personaId = 1

 -- alter para que el nomnbre del departamento cupiera 
  Alter table VACATIONS.Person ADD CONSTRAINT identification_ck UNIQUE (identification)

-- roles
INSERT into VACATIONS.Rol (name, description, createdAt, updatedAt, createdBy, updatedBy) 
  values ('Employee', 'Vacations', GETDATE(), GETDATE(), 305150456, 305150456), 
		 ('Administator', 'Vacations', GETDATE(), GETDATE(), 308900456, 308900456),
		 ('Manager', 'Vacations', GETDATE(), GETDATE(), 208950456, 208950456)
				
-- salarios
INSERT into VACATIONS.Payroll(salary, bonusSalary, createdAt, updatedAt, createdBy, updatedBy) 
  values (450000, 0,  GETDATE(), GETDATE(), 308900456, 308900456),
		 (650000, 0,  GETDATE(), GETDATE(), 308900456, 308900456),
		 (800000, 0,  GETDATE(), GETDATE(), 308900456, 308900456),
		 (550000, 0,  GETDATE(), GETDATE(), 308900456, 308900456) 
		 

-- consejo municipal
INSERT into VACATIONS.Person (name, lastName, identification, email, password, createdAt, updatedAt, createdBy, updatedBy, PayrollRolId) 
  values ('Sonia Lucia','Mata Coto', 305150456,  'sonia2016M@gmail.com', 'ERTdgbby', GETDATE(), GETDATE(), 305150456, 305150456, 3),
		 ('Xiomara','Sánchez Meza', 308900406,  'xiomara2016S@gmail.com', 'adtrTRD', GETDATE(), GETDATE(), 305150456, 305150456, 3),
		 ('William','Solano Durán', 308950476,  'william2016S@gmail.com', 'asdgrtg', GETDATE(), GETDATE(), 305150456, 305150456, 3),
		 ('Damaris','Solano Castillo', 301890456,  'damaria2016S@gmail.com', 'sdfgtre', GETDATE(), GETDATE(), 305150456, 305150456, 3),
		 ('Ivannia Marcela',' Solano Vega', 306750056, 'xiomara2016I@gmail.com', 'RETAdaAFD', GETDATE(), GETDATE(), 305150456, 305150456, 3),	
		 ('Nelson Andrés','Moya Moya', 301320456,  'nelson2016M@gmail.com', 'sdrtrEADF', GETDATE(), GETDATE(), 305150456, 305150456, 3)
 -- alcalde  
  INSERT into VACATIONS.Person (name, lastName, identification, email, password, createdAt, updatedAt, createdBy, updatedBy, PayrollRolId) 
  values 
		 ('Laura','Morales Brenes', 309980166,  'laura2016M@gmail.com', 'Gh567YUTi', GETDATE(), GETDATE(), 305150456, 305150456, 4)

 -- jefe de departamentos 
INSERT into VACATIONS.Person1 (name, lastName, identification, email, password, createdAt, updatedAt, createdBy, updatedBy, PayrollRolId, RolrolId) 
  values ('Maria Antonieta','Morales Ortiz', 309940167,  'maria2016M@gmail.com', 'dajkfdie', GETDATE(), GETDATE(), 305150456, 305150456, 5, 9),
		 ('Luis Alonso','Ramírez Gutierrez', 309600168,  'luis2016M@gmail.com', 'JDKAufy', GETDATE(), GETDATE(), 305150456, 305150456, 5, 9),
		 ('Roxana','Rojas Brenes', 307640167,  'roxana2016M@gmail.com', 'fjklad.', GETDATE(), GETDATE(), 305150456, 305150456, 5, 9),
		 ('Andres','Morales Solano', 308640167,  'andres2016M@gmail.com', 'UudhjsE', GETDATE(), GETDATE(), 305150456, 305150456, 5, 9),
		 ('Carlos Humberto','Coto Alvarado', 304640167,  'carlos2016M@gmail.com', 'DUAbdajv', GETDATE(), GETDATE(), 305150456, 305150456, 5, 9),
		 ('Felicia','Méndez Brenes', 309040167,  'Felicia2016M@gmail.com', 'dnajeHKA', GETDATE(), GETDATE(), 305150456, 305150456, 5, 9),
		 ('Dunia','Ramírez Sánchez', 304650167,  'dunia2016M@gmail.com', 'daiofaIOE', GETDATE(), GETDATE(), 305150456, 305150456, 5, 9),
		 ('Natalia','Ortiz Alvarez', 309640197,  'natalia2016M@gmail.com', 'UYIDAbndm', GETDATE(), GETDATE(), 305150456, 305150456, 5, 9),
		 ('Fernando','Hernández Brenes', 309640137,  'fernando2016M@gmail.com', 'euiabEBS', GETDATE(), GETDATE(), 305150456, 305150456, 5, 9),
		 ('Enrique','Rodriguez Leiva', 304640147,  'Enrique2016M@gmail.com', 'JKJLDidn', GETDATE(), GETDATE(), 305150456, 305150456, 5, 9),
		 ('Douglas','Fonseca Quesada', 302640159,  'douglas2016M@gmail.com', 'djaueeb', GETDATE(), GETDATE(), 305150456, 305150456, 5, 9),
		 ('Marcos','Mata Solano', 309510167,  'marcos2016M@gmail.com', 'euieyrYyu', GETDATE(), GETDATE(), 305150456, 305150456, 5, 9)

 -- empleados por departamento
 --1. RRHH

 Insert into VACATIONS.Person (name, lastName, identification, email, password, createdAt, updatedAt, createdBy, updatedBy, PayrollRolId) 
  values ('Maria Luisa','Figueres Ortiz', 309900117,  'luisa2016M@gmail.com', 'ieoqur', GETDATE(), GETDATE(), 305150456, 305150456, 6),
		 ('Luis Kevin','Ramírez Gutierrez', 309910138,  'kevin2016M@gmail.com', 'AJKDLjkld', GETDATE(), GETDATE(), 305150456, 305150456, 6),
		 ('Carlos','Rojas Soto', 309920167,  'carlos2016M@gmail.com', 'G6da7YUTi', GETDATE(), GETDATE(), 305150456, 305150456, 6), 
		 ('Michael','Morales Rodríguez', 308930107,  'michael2016M@gmail.com', 'afauduej', GETDATE(), GETDATE(), 305150456, 305150456, 6),
		 ('Humberto','Solano Alvarado', 304940147,  'humberto2016M@gmail.com', 'JDhduenN', GETDATE(), GETDATE(), 305150456, 305150456, 6)

 --2. Tecnolgías de Información
Insert into VACATIONS.Person (name, lastName, identification, email, password, createdAt, updatedAt, createdBy, updatedBy, PayrollRolId) 
  values ('Karina','Ramírez Sánchez', 304590167,  'karina2016M@gmail.com', 'dajkeneuNA', GETDATE(), GETDATE(), 305150456, 305150456, 6),
		 ('Natalia','Guillen Alvarez', 309660197,  'natalia2016M@gmail.com', 'DAHJKdja', GETDATE(), GETDATE(), 305150456, 305150456, 6),
		 ('Mariana','Hernández Ramírez', 309740137,  'mariana2016M@gmail.com', 'faeiundJD', GETDATE(), GETDATE(), 305150456, 305150456, 6),
		 ('Sofia','Araya Leiva', 304890147,  'sofia2016M@gmail.com', 'fuioEJNND', GETDATE(), GETDATE(), 305150456, 305150456, 6)
		
		 
 --3. Patentes
Insert into VACATIONS.Person (name, lastName, identification, email, password, createdAt, updatedAt, createdBy, updatedBy, PayrollRolId) 
  values ('Douglas','Fonseca Campos', 309990119,  'douglas2016M@gmail.com', 'Gh567YUTi', GETDATE(), GETDATE(), 305150456, 305150456, 6),
		 ('Fernando','Ortiz Solano', 305230127,  'fernando2016M@gmail.com', 'Gh567YUTi', GETDATE(), GETDATE(), 305150456, 305150456, 6),
		 ('Sandra','Méndez Ruiz', 304970177,  'sandra2016M@gmail.com', 'Gh567YUTi', GETDATE(), GETDATE(), 305150456, 305150456, 6)


		 






		('20170108', 0, GETDATE(), GETDATE(), 8, 8, 45), 
		('20170109', 0, GETDATE(), GETDATE(), 8, 8, 45),
		('20170110', 0, GETDATE(), GETDATE(), 8, 8, 45), 
		('20170127', 0, GETDATE(), GETDATE(), 8, 8, 46), 
		('20160128', 0, GETDATE(), GETDATE(), 8, 8, 46), 
		('20160129', 0, GETDATE(), GETDATE(), 8, 8, 46), 
		('20160130', 0, GETDATE(), GETDATE(), 8, 8, 46), 
		('20150109', 0, GETDATE(), GETDATE(), 8, 8, 47),
		('20180108', 0, GETDATE(), GETDATE(), 8, 8, 47), 
		('20180107', 0, GETDATE(), GETDATE(), 8, 8, 47), 
		('20170106', 0, GETDATE(), GETDATE(), 8, 8, 47),



 --4. Cobros
 --5. Proveeduría
 --6. Catastro
 --7. Contabilidad
 --8. Auditoria Interna
 --9. Administrativo Financiero  
 --10. Presupuesto
 --11. Ingeniería
 --12. Servicios Generales  

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
		 ('Servicios Generales', 309510167, 309940167, GETDATE(), GETDATE(), 309940167)

INSERT into VACATIONS.Person_Rol(PersonpersonaId, RolRolId)
		 values (3, 9), 
				(4, 9),
				(5, 9), 
				(6, 9),
				(7, 9), 
				(8, 9),
				(9, 9), 
				(10, 8),
				(11, 9), 
				(12, 9),
				(13, 9), 
				(14, 9),
				(15, 9), 
				(16, 9),
				(17, 9), 
				(18, 9),
				(19, 9), 
				(20, 7),
				(21, 7), 
				(22, 7),
				(23, 7), 
				(24, 7),
				(25, 7), 
				(26, 7),
				(27, 7),
				(28, 7), 
				(29, 7),
				(30, 7), 
				(31, 7),
				(32, 7), 
				(33, 7)
				

INSERT into VACATIONS.Person_Departament(PersonpersonaId, DepartamentdepartamentId)
		 values (22,1),
				(23,1),
				(24,1),
				(25,1),
				(26,1),
				(27,2),
				(28,2),
				(29,2),
				(30,2),
				(31,3),
				(32,3),
				(33,3)


-------------------------------------------- version 2 -----------------------------------------


 Update VACATIONS.Person1 Set password = '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4' where personaId = 20


  Update VACATIONS.Departament Set PersonPersonaId = 15 Where PersonpersonaId = 309940167
  Update VACATIONS.Departament Set PersonPersonaId = 16 Where PersonpersonaId = 9
  Update VACATIONS.Departament Set PersonPersonaId = 17 Where PersonpersonaId = 307640167
  Update VACATIONS.Departament Set PersonPersonaId = 18 Where PersonpersonaId = 308640167
  Update VACATIONS.Departament Set PersonPersonaId = 19 Where PersonpersonaId = 304640167
  Update VACATIONS.Departament Set PersonPersonaId = 20 Where PersonpersonaId = 304650167
  Update VACATIONS.Departament Set PersonPersonaId = 21 Where PersonpersonaId = 309640197
  Update VACATIONS.Departament Set PersonPersonaId = 22 Where PersonpersonaId = 309640137
  Update VACATIONS.Departament Set PersonPersonaId = 23 Where PersonpersonaId = 304640147
  Update VACATIONS.Departament Set PersonPersonaId = 24 Where PersonpersonaId = 302640159
  Update VACATIONS.Departament Set PersonPersonaId = 25 Where PersonpersonaId = 309510167
  Update VACATIONS.Departament Set PersonPersonaId = 26 Where PersonpersonaId = 309040167

Delete from VACATIONS.Request
Delete from VACATIONS.Day



Select requestId, p.name from VACATIONS.Request as r join VACATIONS.Person1 as p on r.PersonpersonaId = p.personaId
where p.RolrolId = 9
   

    Select requestId, p.name from VACATIONS.Request as r join VACATIONS.Person1 as p on r.PersonpersonaId = p.personaId
  join VACATIONS.Person_Departament pd on pd.PersonpersonaId = p.personaId join VACATIONS.Departament d on d.departamentId = pd.DepartamentdepartamentId 
  where p.RolrolId = 9 