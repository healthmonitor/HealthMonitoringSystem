/*-----------------------------------------------------------------------
* Copyright (c) 2009 Rohini Venkataramaiah , Anuja A Kharade , Navya Jammula.

*This file is part of HealthMonitoringSystem.
*HealthMonitoringSystem is free software: you can redistribute it and/or modify
*it under the terms of the GNU General Public License as published by
*the Free Software Foundation, either version 3 of the License, or
*(at your option) any later version.

*HealthMonitoringSystem is distributed in the hope that it will be useful,
*but WITHOUT ANY WARRANTY; without even the implied warranty of
*MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
*GNU General Public License for more details.

*You should have received a copy of the GNU General Public License
*along with HealthMonitoringSystem.  If not, see
*<http://www.gnu.org/licenses/>.
*-----------------------------------------------------------------------  */

Create database HealthMonitor;

CREATE SEQUENCE login_id_seq
   INCREMENT 1
   START 1;


Create table Login(

id integer not null default nextval('login_id_seq'::regclass),
username Varchar(60),
password varchar(60),
firstname varchar(255),
lastname varchar(255),
dob date,
address varchar(1000),
securityquestion varchar(500),
answer varchar(500),
gender varchar(60),
isadmin boolean,
isdoctor boolean,
isnewuser boolean,
primary key (id)
);

create table patient(
pid bigint,
temperature numeric,
bphigh integer,
bplow integer,
glucose bigint,
painlevel integer,
description varchar(5000),
entrydate date
);

create table doctorremarks(
patientid bigint not null,
doctorid bigint not null,
remarks varchar(5000),
entrydate date
);

create table doctorpatient(
doctorid bigint not null,
patientid bigint not null,
primary key(doctorid , patientid )
);

Insert into login values(1,'testUser','test123','test1','test2',
'1-2-1970','addr','','','F',false,false,true);
