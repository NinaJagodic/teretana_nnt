SELECT COUNT(*) FROM Uplate;
SELECT COUNT(*) FROM Uplate WHERE Status = 'Istekla'
  AND Datum >= '2026-03-10' AND Datum <= '2026-03-10 12:00';
SELECT COUNT(*) FROM Uplate WHERE Status = 'Placena'
  AND Datum >= '2026-01-01' AND Datum < '2026-01-13';
SELECT COUNT(*) FROM Uplate WHERE Status = 'Placena'
  AND Datum >= '2025-01-01' AND Datum < '2026-01-01';