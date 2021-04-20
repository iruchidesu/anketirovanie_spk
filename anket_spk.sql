-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: localhost    Database: anket_spk
-- ------------------------------------------------------
-- Server version	8.0.23

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `prep_answer`
--

DROP TABLE IF EXISTS `prep_answer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `prep_answer` (
  `id` int NOT NULL AUTO_INCREMENT,
  `answer` varchar(200) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `otvet1` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `otvet2` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `otvet3` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `otvet4` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `kol` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prep_answer`
--

LOCK TABLES `prep_answer` WRITE;
/*!40000 ALTER TABLE `prep_answer` DISABLE KEYS */;
/*!40000 ALTER TABLE `prep_answer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `result_prepod`
--

DROP TABLE IF EXISTS `result_prepod`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `result_prepod` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_user` int NOT NULL,
  `result1` int DEFAULT NULL,
  `result2` int DEFAULT NULL,
  `result3` int DEFAULT NULL,
  `result4` int DEFAULT NULL,
  `id_answer` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `id_answer_idx` (`id_answer`),
  KEY `id_user_idx` (`id_user`),
  CONSTRAINT `id_answer` FOREIGN KEY (`id_answer`) REFERENCES `prep_answer` (`id`),
  CONSTRAINT `id_user` FOREIGN KEY (`id_user`) REFERENCES `user_anket` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `result_prepod`
--

LOCK TABLES `result_prepod` WRITE;
/*!40000 ALTER TABLE `result_prepod` DISABLE KEYS */;
/*!40000 ALTER TABLE `result_prepod` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `result_stud`
--

DROP TABLE IF EXISTS `result_stud`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `result_stud` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_user` int NOT NULL,
  `result1` int DEFAULT NULL,
  `result2` int DEFAULT NULL,
  `result3` int DEFAULT NULL,
  `result4` int DEFAULT NULL,
  `result5` int DEFAULT NULL,
  `id_answer` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `id_user_idx` (`id_user`),
  KEY `id_answer_idx` (`id_answer`),
  CONSTRAINT `id_answer1` FOREIGN KEY (`id_answer`) REFERENCES `student_answer` (`id`),
  CONSTRAINT `id_user1` FOREIGN KEY (`id_user`) REFERENCES `user_anket` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `result_stud`
--

LOCK TABLES `result_stud` WRITE;
/*!40000 ALTER TABLE `result_stud` DISABLE KEYS */;
/*!40000 ALTER TABLE `result_stud` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `spec`
--

DROP TABLE IF EXISTS `spec`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `spec` (
  `id` int NOT NULL AUTO_INCREMENT,
  `spec` varchar(4) COLLATE utf8_unicode_ci DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `spec`
--

LOCK TABLES `spec` WRITE;
/*!40000 ALTER TABLE `spec` DISABLE KEYS */;
/*!40000 ALTER TABLE `spec` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student_answer`
--

DROP TABLE IF EXISTS `student_answer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `student_answer` (
  `id` int NOT NULL AUTO_INCREMENT,
  `answer` varchar(500) COLLATE utf8_unicode_ci NOT NULL,
  `otvet1` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `otvet2` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `otvet3` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `otvet4` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `otvet5` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `kol` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student_answer`
--

LOCK TABLES `student_answer` WRITE;
/*!40000 ALTER TABLE `student_answer` DISABLE KEYS */;
/*!40000 ALTER TABLE `student_answer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_anket`
--

DROP TABLE IF EXISTS `user_anket`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_anket` (
  `id` int NOT NULL AUTO_INCREMENT,
  `uid` int NOT NULL,
  `type` varchar(7) COLLATE utf8_unicode_ci DEFAULT NULL,
  `id_spec` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `id_spec_idx` (`id_spec`),
  CONSTRAINT `id_spec` FOREIGN KEY (`id_spec`) REFERENCES `spec` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_anket`
--

LOCK TABLES `user_anket` WRITE;
/*!40000 ALTER TABLE `user_anket` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_anket` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-04-20 12:38:09
