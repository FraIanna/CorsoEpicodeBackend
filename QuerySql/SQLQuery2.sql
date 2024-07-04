-- SELECT *
-- FROM IMPIEGATO
-- WHERE Età > 29

-- WHERE [Reddito Mensile] >= 800.00

-- WHERE [Detrazione fiscale] = 1

-- WHERE [Detrazione fiscale] = 0 

-- WHERE Cognome LIKE 'G%'
-- ORDER BY Cognome

-- SELECT COUNT(*) 
-- FROM IMPIEGATO

-- SELECT [Reddito Mensile]
-- FROM IMPIEGATO

-- SELECT AVG([Reddito Mensile])
-- FROM IMPIEGATO

-- SELECT MAX([Reddito Mensile])
-- FROM IMPIEGATO

-- SELECT MIN([Reddito Mensile])
-- FROM IMPIEGATO

-- SELECT i.*, imp.IdImpiego, imp.Assunzione
-- FROM IMPIEGATO as i
-- JOIN IMPIEGO imp ON i.IdImpiegato = imp.IdImpiego
-- WHERE Assunzione BETWEEN '2007-01-01' AND '2008-01-01';

-- SELECT i.*, imp.IdImpiego, imp.Assunzione
-- FROM IMPIEGATO as i
-- JOIN IMPIEGO imp ON i.IdImpiegato = imp.IdImpiego
-- WHERE [Tipo impiego] = 'Part-time'

-- SELECT AVG([Età])
-- FROM IMPIEGATO