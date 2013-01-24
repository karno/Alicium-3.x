
EXTRA_DIST =  Makefile

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=..

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;"
ASSEMBLY = bin/Debug/Grimoire.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

GRIMOIRE_DLL_MDB_SOURCE=bin/Debug/Grimoire.dll.mdb
GRIMOIRE_DLL_MDB=$(BUILD_DIR)/Grimoire.dll.mdb
NEWTONSOFT_JSON_DLL_SOURCE=../Packages/twitterizer.2.4.1.1/lib/net40/Newtonsoft.Json.dll
TWITTERIZER2_STREAMING_DLL_SOURCE=../Packages/twitterizer.2.4.1.1/lib/net40/Twitterizer2.Streaming.dll
TWITTERIZER2_DLL_SOURCE=../Packages/twitterizer.2.4.1.1/lib/net40/Twitterizer2.dll
ICSHARPCODE_SHARPZIPLIB_DLL_SOURCE=../Packages/SharpZipLib/net-20/ICSharpCode.SharpZipLib.dll

endif

ifeq ($(CONFIG),RELEASE_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/Grimoire.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

GRIMOIRE_DLL_MDB=
NEWTONSOFT_JSON_DLL_SOURCE=../Packages/twitterizer.2.4.1.1/lib/net40/Newtonsoft.Json.dll
TWITTERIZER2_STREAMING_DLL_SOURCE=../Packages/twitterizer.2.4.1.1/lib/net40/Twitterizer2.Streaming.dll
TWITTERIZER2_DLL_SOURCE=../Packages/twitterizer.2.4.1.1/lib/net40/Twitterizer2.dll
ICSHARPCODE_SHARPZIPLIB_DLL_SOURCE=../Packages/SharpZipLib/net-20/ICSharpCode.SharpZipLib.dll

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(GRIMOIRE_DLL_MDB) \
	$(NEWTONSOFT_JSON_DLL) \
	$(TWITTERIZER2_STREAMING_DLL) \
	$(TWITTERIZER2_DLL) \
	$(ICSHARPCODE_SHARPZIPLIB_DLL)  

LINUX_PKGCONFIG = \
	$(GRIMOIRE_PC)  


RESGEN=resgen2

NEWTONSOFT_JSON_DLL = $(BUILD_DIR)/Newtonsoft.Json.dll
TWITTERIZER2_STREAMING_DLL = $(BUILD_DIR)/Twitterizer2.Streaming.dll
TWITTERIZER2_DLL = $(BUILD_DIR)/Twitterizer2.dll
ICSHARPCODE_SHARPZIPLIB_DLL = $(BUILD_DIR)/ICSharpCode.SharpZipLib.dll
GRIMOIRE_PC = $(BUILD_DIR)/grimoire.pc

FILES = \
	Events.cs \
	PluginBase.cs \
	Magic.cs \
	Plugin.cs \
	Settings.cs \
	Exceptions.cs \
	Guignol.cs \
	Manage.cs \
	Package.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	grimoire.pc.in 

REFERENCES =  \
	System.Xml \
	System \
	System.Core \
	System.Data \
	System.Xml.Linq \
	System.Data.Linq \
	System.Net \
	System.Web \
	System.Drawing \
	-pkg:gtk-sharp-2.0 \
	Mono.Posix

DLL_REFERENCES =  \
	../Packages/twitterizer.2.4.1.1/lib/net40/Newtonsoft.Json.dll \
	../Packages/twitterizer.2.4.1.1/lib/net40/Twitterizer2.Streaming.dll \
	../Packages/twitterizer.2.4.1.1/lib/net40/Twitterizer2.dll \
	../Packages/SharpZipLib/net-20/ICSharpCode.SharpZipLib.dll

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

#Targets
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG)  $(top_srcdir)/config.make

include $(top_srcdir)/Makefile.include
#include $(srcdir)/custom-hooks.make



$(eval $(call emit-deploy-target,NEWTONSOFT_JSON_DLL))
$(eval $(call emit-deploy-target,TWITTERIZER2_STREAMING_DLL))
$(eval $(call emit-deploy-target,TWITTERIZER2_DLL))
$(eval $(call emit-deploy-target,ICSHARPCODE_SHARPZIPLIB_DLL))
$(eval $(call emit-deploy-wrapper,GRIMOIRE_PC,grimoire.pc))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'


$(ASSEMBLY_MDB): $(ASSEMBLY)
$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	make pre-all-local-hook prefix=$(prefix)
	mkdir -p $(shell dirname $(ASSEMBLY))
	make $(CONFIG)_BeforeBuild
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
	make $(CONFIG)_AfterBuild
	make post-all-local-hook prefix=$(prefix)

install-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-install-local-hook prefix=$(prefix)
	make install-satellite-assemblies prefix=$(prefix)
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)'
	$(call cp,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(GRIMOIRE_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(NEWTONSOFT_JSON_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(TWITTERIZER2_STREAMING_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(TWITTERIZER2_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ICSHARPCODE_SHARPZIPLIB_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(libdir)/pkgconfig'
	$(call cp,$(GRIMOIRE_PC),$(DESTDIR)$(libdir)/pkgconfig)
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(GRIMOIRE_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(NEWTONSOFT_JSON_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(TWITTERIZER2_STREAMING_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(TWITTERIZER2_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ICSHARPCODE_SHARPZIPLIB_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(GRIMOIRE_PC),$(DESTDIR)$(libdir)/pkgconfig)
	make post-uninstall-local-hook prefix=$(prefix)

install: install-local
uninstall: uninstall-local
clean: clean-local

include $(top_srcdir)/rules.make
