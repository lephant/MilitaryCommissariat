CREATE DATABASE  IF NOT EXISTS `military_commissariat` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `military_commissariat`;
-- MySQL dump 10.13  Distrib 5.7.9, for Win32 (AMD64)
--
-- Host: localhost    Database: military_commissariat
-- ------------------------------------------------------
-- Server version	5.7.12-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `addresses`
--

DROP TABLE IF EXISTS `addresses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `addresses` (
  `draftee_id` bigint(20) NOT NULL,
  `municipal_district` varchar(512) DEFAULT NULL,
  `mail_index` varchar(64) DEFAULT NULL,
  `street_name` varchar(256) DEFAULT NULL,
  `house_number` varchar(64) DEFAULT NULL,
  `housing_number` varchar(64) DEFAULT NULL,
  `apartment` varchar(128) DEFAULT NULL,
  `home_phone` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`draftee_id`),
  CONSTRAINT `addresses_draftees_fk` FOREIGN KEY (`draftee_id`) REFERENCES `draftees` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `documents`
--

DROP TABLE IF EXISTS `documents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `documents` (
  `draftee_id` bigint(20) NOT NULL,
  `passport_series` varchar(64) DEFAULT NULL,
  `passport_number` varchar(64) DEFAULT NULL,
  `passport_issue_date` date DEFAULT NULL,
  `passport_issued_by` varchar(512) DEFAULT NULL,
  `certificate_series` varchar(64) DEFAULT NULL,
  `certificate_number` varchar(64) DEFAULT NULL,
  `certificate_issue_date` date DEFAULT NULL,
  `ticket_series` varchar(64) DEFAULT NULL,
  `ticket_number` varchar(64) DEFAULT NULL,
  `ticket_issue_date` date DEFAULT NULL,
  PRIMARY KEY (`draftee_id`),
  CONSTRAINT `documents_draftee_fk` FOREIGN KEY (`draftee_id`) REFERENCES `draftees` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `draftees`
--

DROP TABLE IF EXISTS `draftees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `draftees` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `last_name` varchar(128) DEFAULT NULL,
  `first_name` varchar(128) DEFAULT NULL,
  `patronymic` varchar(128) DEFAULT NULL,
  `birth_place` varchar(512) DEFAULT NULL,
  `birth_date` date DEFAULT NULL,
  `category` varchar(64) DEFAULT NULL,
  `troop_type` varchar(512) DEFAULT NULL,
  `foreign_languages` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `relatives`
--

DROP TABLE IF EXISTS `relatives`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `relatives` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `draftee_id` bigint(20) NOT NULL,
  `relationship_type` varchar(64) DEFAULT NULL,
  `full_name` varchar(512) DEFAULT NULL,
  `birth_year` int(11) DEFAULT NULL,
  `birth_place` varchar(512) DEFAULT NULL,
  `work_place` varchar(512) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `relatives_draftees_fk_idx` (`draftee_id`),
  CONSTRAINT `relatives_draftees_fk` FOREIGN KEY (`draftee_id`) REFERENCES `draftees` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `study_places`
--

DROP TABLE IF EXISTS `study_places`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `study_places` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `draftee_id` bigint(20) NOT NULL,
  `education` varchar(128) NOT NULL,
  `name` varchar(512) NOT NULL,
  `institution_type` varchar(128) NOT NULL,
  `end_date` date DEFAULT NULL,
  `faculty` varchar(256) NOT NULL,
  `specialty` varchar(256) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `study_places_draftees_fk_idx` (`draftee_id`),
  CONSTRAINT `study_places_draftees_fk` FOREIGN KEY (`draftee_id`) REFERENCES `draftees` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping events for database 'military_commissariat'
--

--
-- Dumping routines for database 'military_commissariat'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-10-07 19:53:45
