-- phpMyAdmin SQL Dump
-- version 3.4.5
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Jan 11, 2018 at 10:57 AM
-- Server version: 5.5.16
-- PHP Version: 5.3.8

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `himifda`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE IF NOT EXISTS `admin` (
  `username` varchar(10) NOT NULL,
  `password` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`username`, `password`) VALUES
('himifda', 'nanas02'),
('admin', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `denda`
--

CREATE TABLE IF NOT EXISTS `denda` (
  `kode_brg` varchar(10) NOT NULL,
  `kode_pjm` varchar(10) NOT NULL,
  `tgl_balik` date NOT NULL,
  `status_denda` int(10) NOT NULL,
  `total_byr` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `inventaris`
--

CREATE TABLE IF NOT EXISTS `inventaris` (
  `No_brg` int(10) NOT NULL AUTO_INCREMENT,
  `tgl_masuk` datetime NOT NULL,
  `nama_brg` varchar(20) NOT NULL,
  `jmlh_brg` int(5) NOT NULL,
  `Tersedia` varchar(20) NOT NULL,
  PRIMARY KEY (`No_brg`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=41 ;

--
-- Dumping data for table `inventaris`
--

INSERT INTO `inventaris` (`No_brg`, `tgl_masuk`, `nama_brg`, `jmlh_brg`, `Tersedia`) VALUES
(35, '2017-12-27 00:00:00', ' KIPAS ANGIN ', 1, ' TERSEDIA '),
(37, '2017-12-29 00:00:00', ' KURSI PLASTIK ', 3, ' TERSEDIA '),
(38, '2017-12-29 00:00:00', ' SPIDOL HITAM ', 2, ' TERSEDIA '),
(39, '2017-12-29 00:00:00', '  LAPTOP  ', 1, ' TERSEDIA '),
(40, '2018-01-05 00:00:00', '    KABEL VGA    ', 10, ' TERSEDIA');

-- --------------------------------------------------------

--
-- Table structure for table `keuangan`
--

CREATE TABLE IF NOT EXISTS `keuangan` (
  `No_ID` int(11) NOT NULL AUTO_INCREMENT,
  `tanggal` datetime NOT NULL,
  `debit` varchar(10) NOT NULL,
  `credit` varchar(10) NOT NULL,
  `saldo` varchar(10) NOT NULL,
  `keterangan` varchar(50) NOT NULL,
  PRIMARY KEY (`No_ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=125 ;

--
-- Dumping data for table `keuangan`
--

INSERT INTO `keuangan` (`No_ID`, `tanggal`, `debit`, `credit`, `saldo`, `keterangan`) VALUES
(107, '2017-12-29 00:00:00', ' 10000 ', ' 0 ', ' 240000 ', ' DENDA BARANG '),
(109, '2017-12-29 00:00:00', ' 0 ', ' 200000 ', ' 140000 ', ' UNTUK BELI PAPAN '),
(110, '2017-12-30 00:00:00', ' 10000 ', ' 0 ', ' 350000 ', ' DENDA BARANG '),
(111, '2017-12-29 00:00:00', ' 10000 ', ' 0 ', ' 360000 ', ' DENDA BARANG '),
(112, '2017-12-29 00:00:00', ' 10000 ', ' 0 ', ' 370000 ', ' DENDA BARANG '),
(113, '2017-12-29 00:00:00', '20000', '0', ' 370000 ', ' BELI PULSA HUMAS '),
(114, '2018-01-01 00:00:00', ' 10000 ', ' 0 ', ' 380000 ', ' DENDA BARANG '),
(115, '2018-01-02 00:00:00', '10000', '0', '390000', 'BENSIN'),
(121, '2018-01-05 00:00:00', '10000', '0', '400000', ' DENDA BARANG '),
(122, '2018-01-05 00:00:00', '0', '10000', '390000', 'BENSIN'),
(123, '2018-01-05 00:00:00', ' 0', ' 10000', '380000', ' BELI CAT');

-- --------------------------------------------------------

--
-- Table structure for table `laporan`
--

CREATE TABLE IF NOT EXISTS `laporan` (
  `no_laporan` int(10) NOT NULL AUTO_INCREMENT,
  `tgl_pinjam` datetime NOT NULL,
  `atas_nama` varchar(20) NOT NULL,
  `nama_brg` varchar(20) NOT NULL,
  `jml_brg` int(20) NOT NULL,
  `tgl_blk` datetime NOT NULL,
  PRIMARY KEY (`no_laporan`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=90 ;

--
-- Dumping data for table `laporan`
--

INSERT INTO `laporan` (`no_laporan`, `tgl_pinjam`, `atas_nama`, `nama_brg`, `jml_brg`, `tgl_blk`) VALUES
(46, '2017-12-30 00:00:00', 'NANAS', ' KURSI PLASTIK ', 3, '2018-01-02 00:00:00'),
(47, '2017-12-30 00:00:00', 'AGAW', ' SPIDOL HITAM ', 3, '2018-01-02 00:00:00'),
(48, '2017-12-30 00:00:00', 'AGAW', ' SPIDOL HITAM ', 2, '2018-01-02 00:00:00'),
(49, '2017-12-29 00:00:00', 'AGAW', ' SPIDOL HITAM ', 2, '2018-01-01 00:00:00'),
(50, '2017-12-29 00:00:00', 'AJENG', ' SPIDOL HITAM ', 2, '2018-01-02 00:00:00'),
(51, '2018-01-01 00:00:00', 'ERMA', ' SPIDOL HITAM ', 2, '2017-12-04 00:00:00'),
(52, '2018-01-01 00:00:00', 'BU TIMOR', ' KURSI PLASTIK ', 1, '2017-12-04 00:00:00'),
(53, '2018-01-01 00:00:00', 'VIJAY', ' KURSI PLASTIK ', 2, '2017-12-04 00:00:00'),
(54, '2018-01-25 00:00:00', 'NANAS', '  PAPAN TULIS  ', 1, '2017-12-29 00:00:00'),
(55, '2017-12-29 00:00:00', 'NGIJAN', '  PAPAN TULIS  ', 1, '2018-01-02 00:00:00'),
(56, '2017-12-29 00:00:00', 'GIJUN', ' SPIDOL HITAM ', 6, '2018-01-02 00:00:00'),
(57, '2017-12-29 00:00:00', 'HJKH', ' SPIDOL HITAM ', 1, '2018-01-06 00:00:00'),
(58, '2017-12-29 00:00:00', 'ERMA', '  PAPAN TULIS  ', 4, '2017-12-29 00:00:00'),
(59, '2017-12-29 00:00:00', 'TYAS', '  PAPAN TULIS  ', 5, '2018-01-06 00:00:00'),
(60, '2017-12-29 00:00:00', 'NANAS', ' SPIDOL HITAM ', 0, '2018-01-02 00:00:00'),
(61, '2017-12-29 00:00:00', 'TYAS', ' SPIDOL HITAM ', 0, '2018-01-02 00:00:00'),
(62, '2017-12-29 00:00:00', 'TYAS', ' SPIDOL HITAM ', 4, '2018-01-02 00:00:00'),
(63, '2018-01-02 00:00:00', 'k', ' KABEL VGA ', 1, '2018-01-05 00:00:00'),
(64, '2018-01-02 00:00:00', 'jjj', ' KABEL VGA ', 1, '2018-01-05 00:00:00'),
(65, '2018-01-02 00:00:00', 'NANAS', ' KABEL VGA ', 4, '2018-01-05 00:00:00'),
(66, '2018-01-02 00:00:00', 'KODI', ' KABEL VGA ', 3, '2018-01-05 00:00:00'),
(67, '2018-01-02 00:00:00', 'ARIS', ' KABEL VGA ', 8, '2018-01-06 00:00:00'),
(68, '2018-01-02 00:00:00', 'NNN', ' KABEL VGA ', 10, '2018-01-05 00:00:00'),
(69, '2018-01-02 00:00:00', 'KOK', '  KABEL VGA  ', 10, '2018-01-06 00:00:00'),
(70, '2018-01-02 00:00:00', 'TYO', '  KABEL VGA  ', 4, '2018-01-05 00:00:00'),
(71, '2018-01-02 00:00:00', 'ada', '  KABEL VGA  ', 1, '2018-01-05 00:00:00'),
(72, '2018-01-04 00:00:00', 'WARDAH', '  KABEL VGA  ', 10, '2018-01-04 00:00:00'),
(73, '2018-01-04 00:00:00', 'ANISA', '  KABEL VGA  ', 2, '2018-01-04 00:00:00'),
(74, '2018-01-04 00:00:00', 'WARDAH', '  KABEL VGA  ', 8, '2018-01-04 00:00:00'),
(75, '2018-01-04 00:00:00', 'POPO', '  KABEL VGA  ', 8, '2018-01-06 00:00:00'),
(76, '2018-01-04 00:00:00', 'LOLI', ' KABEL VGA   ', 10, '2018-01-04 00:00:00'),
(77, '2018-01-04 00:00:00', 'UU', ' KABEL VGA   ', 9, '2018-01-04 00:00:00'),
(78, '2018-01-04 00:00:00', 'KJH', ' KABEL VGA   ', 7, '2018-01-06 00:00:00'),
(79, '2018-01-04 00:00:00', 'OIO', ' KABEL VGA   ', 8, '2018-01-04 00:00:00'),
(80, '2018-01-04 00:00:00', 'JAKSD', '   KABEL VGA   ', 9, '2018-01-04 00:00:00'),
(81, '2018-01-04 00:00:00', 'HJDSA', '   KABEL VGA   ', 1, '2018-01-04 00:00:00'),
(82, '2018-01-04 00:00:00', 'JHG', '   KABEL VGA   ', 9, '2018-01-04 00:00:00'),
(83, '2018-01-05 00:00:00', 'MITA', 'KABEL VGA   ', 10, '2018-01-09 00:00:00'),
(84, '2018-01-05 00:00:00', 'MITA', 'KABEL VGA   ', 8, '2018-01-08 00:00:00'),
(85, '2018-01-05 00:00:00', 'NANAS', '   KABEL VGA   ', 10, '2018-01-09 00:00:00'),
(86, '2018-01-05 00:00:00', 'HSJGF', '   KABEL VGA   ', 10, '2018-01-09 00:00:00'),
(87, '2018-01-05 00:00:00', 'NANAS', '   KABEL VGA   ', 10, '2018-01-09 00:00:00'),
(88, '2018-01-05 00:00:00', 'NANAS', '    KABEL VGA    ', 10, '2018-01-09 00:00:00'),
(89, '2018-01-05 00:00:00', 'NANAS', '    KABEL VGA    ', 10, '2018-01-09 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `pengembalian`
--

CREATE TABLE IF NOT EXISTS `pengembalian` (
  `kode_balik` int(10) NOT NULL AUTO_INCREMENT,
  `atas_nama` varchar(20) NOT NULL,
  `nama_brg` varchar(20) NOT NULL,
  `tgl_pinjam` varchar(20) NOT NULL,
  `tgl_balik` varchar(20) NOT NULL,
  `denda` varchar(20) NOT NULL,
  `jml_brg` int(10) NOT NULL,
  PRIMARY KEY (`kode_balik`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=121 ;

--
-- Dumping data for table `pengembalian`
--

INSERT INTO `pengembalian` (`kode_balik`, `atas_nama`, `nama_brg`, `tgl_pinjam`, `tgl_balik`, `denda`, `jml_brg`) VALUES
(69, 'KURSI', 'HMM', '2017-12-29', '2018-01-03', ' 10000 ', 1),
(70, '  MENGHAPUS  ', 'KARINA', '2017-12-26', '2017-12-29', ' 10000 ', 1),
(71, ' GALON ', 'GATRA', '2017-12-29', '2017-12-29', '0', 1),
(72, '  MENGHAPUS  ', 'DOYOK', '2017-12-29', '2017-12-29', '0', 10),
(73, '  MENGHAPUS  ', 'OJI', '2017-12-29', '2017-12-29', '0', 100),
(74, 'MENGHAPUS   ', 'ALIF', '2017-12-29', '2017-12-29', '0', 50),
(75, ' GALON ', 'NANAS', '2017-12-29', '2017-12-29', '0', 5),
(76, ' GALON ', 'NANS', '2017-12-29', '2017-12-29', '0', 2),
(77, ' GALON ', 'MUNAS', '2017-12-29', '2017-12-29', '0', 20),
(78, ' GALON ', 'GATHERING', '2017-12-29', '2017-12-29', '0', 200),
(79, '  GALON  ', 'ERMA', '2017-12-29', '2017-12-29', '0', 20),
(80, '   GALON   ', 'ERMA', '2017-12-29', '2017-12-29', '0', 20),
(81, ' PELAN ', 'KAY', '2017-12-29', '2018-01-03', ' 10000 ', 1),
(82, '   MENGHAPUS   ', 'ZUL', '2017-12-29', '2018-01-03', ' 10000 ', 70),
(83, '  KURSI PLASTIK  ', ' NANAS', '2017-12-30', '2018-01-04', ' 10000 ', 2),
(84, ' SPIDOL HITAM ', 'AGAW', '2017-12-29', '2018-01-04', ' 10000 ', 2),
(85, ' SPIDOL HITAM ', 'AJENG', '2017-12-29', '2018-01-03', ' 10000 ', 2),
(86, ' SPIDOL HITAM ', 'ERMA', '2018-01-01', '2018-01-05', ' 10000 ', 2),
(87, '  PAPAN TULIS  ', 'NGIJAN', '2017-12-29', '2017-12-29', '0', 1),
(88, '  PAPAN TULIS  ', 'NANAS', '2018-01-25', '2017-12-29', '0', 1),
(89, ' KURSI PLASTIK ', 'VIJAY', '2018-01-01', '2017-12-29', '0', 2),
(90, ' KURSI PLASTIK ', 'BU TIMOR', '2018-01-01', '2017-12-29', '0', 1),
(91, ' SPIDOL HITAM ', 'GIJUN', '2017-12-29', '2017-12-29', '0', 6),
(92, '  PAPAN TULIS  ', 'ERMA', '2017-12-29', '2017-12-29', '0', 4),
(93, ' KABEL VGA ', 'k', '2018-01-02', '2018-01-17', ' 10000 ', 1),
(94, ' KABEL VGA ', 'NANAS', '2018-01-02', '2018-01-05', '0', 4),
(95, ' KABEL VGA ', 'KODI', '2018-01-02', '2018-01-05', '0', 3),
(96, ' KABEL VGA ', 'jjj', '2018-01-02', '2018-01-05', '0', 1),
(97, 'ARIS', ' KABEL VGA ', '2018-01-02', '2018-01-06', ' 10000 ', 8),
(98, 'NNN', ' KABEL VGA ', '2018-01-02', '2018-01-05', '0', 10),
(99, 'KOK', '  KABEL VGA  ', '2018-01-02', '2018-01-06', ' 10000 ', 10),
(100, 'TYAS', '  PAPAN TULIS  ', '2017-12-29', '2018-01-06', ' 10000 ', 5),
(101, 'HJKH', ' SPIDOL HITAM ', '2017-12-29', '2018-01-06', ' 10000 ', 1),
(102, 'TYO', '  KABEL VGA  ', '2018-01-02', '2018-01-05', '0', 4),
(103, 'ada', '  KABEL VGA  ', '2018-01-02', '2018-01-05', '0', 1),
(104, 'WARDAH', '  KABEL VGA  ', '2018-01-04', '2018-01-08', ' 10000 ', 10),
(105, 'WARDAH', '  KABEL VGA  ', '2018-01-04', '2018-01-04', '0', 8),
(106, 'ANISA', '  KABEL VGA  ', '2018-01-04', '2018-01-04', '0', 2),
(107, 'POPO', '  KABEL VGA  ', '2018-01-04', '2018-01-06', '0', 8),
(108, 'LOLI', ' KABEL VGA   ', '2018-01-04', '2018-01-04', '0', 10),
(109, 'UU', ' KABEL VGA   ', '2018-01-04', '2018-01-04', '0', 9),
(110, 'KJH', 'KABEL VGA   ', '2018-01-04', '2018-01-04', '0', 7),
(111, 'OIO', ' KABEL VGA   ', '2018-01-04', '2018-01-04', '0', 8),
(112, 'JAKSD', '   KABEL VGA   ', '2018-01-04', '2018-01-04', '0', 9),
(113, 'HJDSA', '   KABEL VGA   ', '2018-01-04', '2018-01-04', '0', 1),
(114, 'JHG', '   KABEL VGA   ', '2018-01-04', '2018-01-04', '0', 9),
(115, 'MITA', 'KABEL VGA   ', '2018-01-05', '2018-01-09', '10000 ', 10),
(116, 'NANAS', '   KABEL VGA   ', '2018-01-05', '2018-01-08', '0', 10),
(117, 'HSJGF', '   KABEL VGA   ', '2018-01-05', '2018-01-09', ' 10000 ', 10),
(118, 'NANAS', '   KABEL VGA   ', '2018-01-05', '2018-01-09', ' 10000 ', 10),
(119, 'NANAS', '    KABEL VGA    ', '2018-01-05', '2018-01-05', '0', 10),
(120, 'NANAS', '    KABEL VGA    ', '2018-01-05', '2018-01-09', ' 10000 ', 10);

-- --------------------------------------------------------

--
-- Table structure for table `pinjaman`
--

CREATE TABLE IF NOT EXISTS `pinjaman` (
  `kode_pjm` int(10) NOT NULL AUTO_INCREMENT,
  `tgl_pinjam` datetime NOT NULL,
  `nama_brg` varchar(20) NOT NULL,
  `nama_peminjam` varchar(20) NOT NULL,
  `jml_brg` int(10) NOT NULL,
  `tgl_kembali` datetime NOT NULL,
  PRIMARY KEY (`kode_pjm`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=120 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
