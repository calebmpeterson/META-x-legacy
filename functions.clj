(ns functions
  (:require [clojure.string :as string])
  (:import [System.Windows.Forms Clipboard SendKeys]))



;;
;; Debugging
;;

(defn- trace-tap [obj]
  (do
    (System.Diagnostics.Trace/WriteLine (.ToString obj))
    obj))



;;
;; Clipboard
;;

(defn from-clipboard! [] (Clipboard/GetText))
(defn into-clipboard! [obj] (Clipboard/SetText (str obj)))

(defn copy! [] (SendKeys/Send "^c"))
(defn paste! [] (SendKeys/Send "^v"))

(defn >> [f]
  (do
    (copy!)
    (-> (from-clipboard!)
        (trace-tap)
        (f)
        (trace-tap)
        (into-clipboard!))
    (paste!)))



;;
;; Text Manipulation
;;

(defn to-upper
  "Convert text to ALL UPPER CASE"
  [obj] (string/upper-case (str obj)))

(defn to-lower
  "Convert text to all lower case"
  [obj] (string/lower-case (str obj)))

(defn to-scentence
  "Convert text to Scentence case"
  [obj] (string/capitalize (str obj)))

(System.Diagnostics.Trace/WriteLine "reload functions.clj")