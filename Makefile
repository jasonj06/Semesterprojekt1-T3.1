TARGETS = \
	woz.zip \

SOURCE_DIRS = Game World Items Situations
SOURCE_FILES = $(wildcard $(addsuffix /*.cs,$(SOURCE_DIRS)))


all: ${TARGETS}

clean:
	touch dummy~
	rm        *~

mrproper: clean
	touch  bin obj
	rm -Rf bin obj


woz.zip: Makefile $(SOURCE_DIRS) $(SOURCE_FILES)
	@stage=$$(mktemp -d .woz.XXXXXX) && \
	stage=$$(cd "$$stage" && pwd -P) && \
	case "$$stage" in "$$(pwd -P)"/.woz.*) ;; *) exit 1 ;; esac && \
	trap 'rm -rf "$$stage"' EXIT && \
	for dir in $(SOURCE_DIRS); do \
		mkdir -p "$$stage/woz/$$dir" && \
		cp "$$dir"/*.cs "$$stage/woz/$$dir/" || exit 1; \
	done && \
	(cd "$$stage" && zip -r woz.zip woz) && \
	mv "$$stage/woz.zip" "$@"


build:
	dotnet build

run:
	dotnet run

